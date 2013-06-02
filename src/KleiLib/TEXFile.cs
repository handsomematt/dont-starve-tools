#region License
/*
Klei Studio is licensed under the MIT license.
Copyright © 2013 Matt Stevens

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace KleiLib
{
    public class TEXFile
    {
        public class InvalidTEXFileException : System.Exception { public InvalidTEXFileException(string msg) : base(msg) { } };

        public enum Platform
        {
            PC = 12,
            XBOX360 = 11,
            PS3 = 10,
            Unknown = 0
        };

        public enum PixelFormat : uint
        {
            DXT1 = 0, DXT3 = 1, DXT5 = 2,
            ARGB = 4,
            Unknown = 7
        };

        public enum TextureType : uint
        {
            [Description("1D")]
            OneD = 1,
            [Description("2D")]
            TwoD = 2,
            [Description("3D")]
            ThreeD = 3,
            [Description("Cube Mapped")]
            Cubemap = 4
        };

        public readonly char[] KTEXHeader = new char[] { 'K', 'T', 'E', 'X' };

        public struct FileStruct
        {
            public struct HeaderStruct
            {
                public uint Platform;
                public uint PixelFormat;
                public uint TextureType;
                public uint NumMips;
                public uint Flags;
                public uint Remainder;
            }

            public HeaderStruct Header;
            public byte[] Raw;
        }

        public FileStruct File;

        public struct Mipmap
        {
            public ushort Width;
            public ushort Height;
            public ushort Pitch;
            public uint DataSize;
            public byte[] Data;
        };

        public TEXFile() { }
        public TEXFile(Stream stream)
        {
            using (var reader = new BinaryReader(stream))
            {
                if (!reader.ReadChars(4).SequenceEqual(KTEXHeader))
                    throw new InvalidTEXFileException("The first 4 bytes do not match 'KTEX'.");

                var header = reader.ReadUInt32();

                Console.WriteLine(Convert.ToString(header, 2));

                File.Header.Platform = header & 15;
                File.Header.PixelFormat = (header >> 4)  & 31;
                File.Header.TextureType = (header >> 9)  & 15;
                File.Header.NumMips = (header >> 13) & 31;
                File.Header.Flags = (header >> 18) & 3;
                File.Header.Remainder = (header >> 20) & 4095;

                // Just a little hack for pre cave updates, can remove later.
                OldRemainder = (header >> 14) & 262143;

                File.Raw = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
            }
        }

        /* A little hacky but it gets the job done. */
        private uint OldRemainder;
        public bool IsPreCaveUpdate() { return OldRemainder == 262143; }

        public Mipmap[] GetMipmaps()
        {
            Mipmap[] mipmapArray = new Mipmap[File.Header.NumMips];

            using (var reader = new BinaryReader(new MemoryStream(File.Raw))) {
                for (int i = 0; i < File.Header.NumMips; i++) {
                    mipmapArray[i] = new Mipmap();
                    mipmapArray[i].Width = reader.ReadUInt16();
                    mipmapArray[i].Height = reader.ReadUInt16();
                    mipmapArray[i].Pitch = reader.ReadUInt16();
                    mipmapArray[i].DataSize = reader.ReadUInt32();
                }

                for (int i = 0; i < File.Header.NumMips; i++)
                    mipmapArray[i].Data = reader.ReadBytes((int)mipmapArray[i].DataSize);
            }

            return mipmapArray;
        }

        public Mipmap[] GetMipmapsSummary()
        {
            Mipmap[] mipmapArray = new Mipmap[File.Header.NumMips];

            using (var reader = new BinaryReader(new MemoryStream(File.Raw)))
                for (int i = 0; i < File.Header.NumMips; i++) {
                    mipmapArray[i] = new Mipmap();
                    mipmapArray[i].Width = reader.ReadUInt16();
                    mipmapArray[i].Height = reader.ReadUInt16();
                    mipmapArray[i].Pitch = reader.ReadUInt16();
                    mipmapArray[i].DataSize = reader.ReadUInt32();
                }

            return mipmapArray;
        }

        public Mipmap GetMainMipmap()
        {
            Mipmap mipmap = new Mipmap();

            using (var reader = new BinaryReader(new MemoryStream(File.Raw)))
            {
                mipmap.Width = reader.ReadUInt16();
                mipmap.Height = reader.ReadUInt16();
                mipmap.Pitch = reader.ReadUInt16();
                mipmap.DataSize = reader.ReadUInt32();

                reader.BaseStream.Seek((File.Header.NumMips - 1) * 10, SeekOrigin.Current);

                mipmap.Data = reader.ReadBytes((int)mipmap.DataSize);
            }

            return mipmap;
        }

        public Mipmap GetMainMipmapSummary()
        {
            Mipmap mipmap = new Mipmap();

            using (var reader = new BinaryReader(new MemoryStream(File.Raw)))
            {
                mipmap.Width = reader.ReadUInt16();
                mipmap.Height = reader.ReadUInt16();
                mipmap.Pitch = reader.ReadUInt16();
                mipmap.DataSize = reader.ReadUInt32();
            }

            return mipmap;
        }

        public void SaveFile(Stream stream)
        {
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(KTEXHeader);

                uint header = 0;

                header |= 4095;
                header <<= 2;
                header |= File.Header.Flags;
                header <<= 5;
                header |= File.Header.NumMips;
                header <<= 4;
                header |= File.Header.TextureType;
                header <<= 5;
                header |= File.Header.PixelFormat;
                header <<= 4;
                header |= File.Header.Platform;

                writer.Write(header);

                writer.Write(File.Raw);
            }
        }
    }
}

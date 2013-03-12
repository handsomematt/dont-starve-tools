using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

using System.IO;
using System.IO.Compression;

namespace texdecompress
{
    class Program
    {
        enum KTEXDataFormat {
            DXT1,
            DXT1M,
            DXT3,
            DXT3M,
            DXT5,
            DXT5M, // mipmapped
            ARGB,
            ARGBM,
            RGB,
            Unknown
        }

        static string m_FileInName;

        static BinaryReader m_FileIn;
        static BinaryWriter m_FileOut;

        static KTEXDataFormat m_DataFormat;

        static void DoError(string str) {
            Console.WriteLine(str);
            Environment.Exit(0);
        }

        struct mipmap
        {
            public ushort width;
            public ushort height;
            public ushort pitch;
            public uint size;
        };

        static void Main(string[] args)
        {
            if (args.Length < 1)
                DoError("Usage: texdecompress file.tex");

            m_FileInName = args[0];
            m_FileIn = new BinaryReader(new FileStream(m_FileInName, FileMode.Open));

            if (m_FileIn.ReadByte() != 'K' || m_FileIn.ReadByte() != 'T' || m_FileIn.ReadByte() != 'E' || m_FileIn.ReadByte() != 'X')
                DoError("Header doesn't match KTEX! Sorry.");

            var value = BitConverter.ToUInt32(m_FileIn.ReadBytes(4), 0);
            var platform = value & 0x07;
            var pixelFormat = (value >> 3) & 0x07;
            var numberOfMips = (value >> 6) & 0x0F;
            var flag = (value >> 10) & 0x01;

            if (flag == 0)
                numberOfMips = 1;
            else
                numberOfMips = 7; // EEK, THIS NEEDS CHANGING!!

            if (pixelFormat == 0 && flag == 0)
                m_DataFormat = KTEXDataFormat.DXT1;
            else if (pixelFormat == 0 && flag == 1)
                m_DataFormat = KTEXDataFormat.DXT1M;
            else if (pixelFormat == 2 && flag == 0)
                m_DataFormat = KTEXDataFormat.DXT5;
            else if (pixelFormat == 2 && flag == 1)
                m_DataFormat = KTEXDataFormat.DXT5M;
            else if (pixelFormat == 4 & flag == 0)
                m_DataFormat = KTEXDataFormat.ARGB;
            else if (pixelFormat == 4 & flag == 1)
                m_DataFormat = KTEXDataFormat.ARGBM;
            else if (pixelFormat == 5 & flag == 0)
                m_DataFormat = KTEXDataFormat.RGB;
            else
                m_DataFormat = KTEXDataFormat.Unknown;

            var mipmaps = new mipmap[numberOfMips];

            for (int i = 0; i < numberOfMips; i++) {
                mipmaps[i] = new mipmap();
                mipmaps[i].width = m_FileIn.ReadUInt16();
                mipmaps[i].height = m_FileIn.ReadUInt16();
                mipmaps[i].pitch = m_FileIn.ReadUInt16();
                mipmaps[i].size = m_FileIn.ReadUInt32();
            }

            for (int i = 0; i < numberOfMips; i++)
            {
                if (m_DataFormat == KTEXDataFormat.ARGB || m_DataFormat == KTEXDataFormat.ARGBM)
                    WriteARGB(i, mipmaps[i]);
                if (m_DataFormat == KTEXDataFormat.DXT1 || m_DataFormat == KTEXDataFormat.DXT1M)
                    WriteDXT1(i, mipmaps[i]);
                if (m_DataFormat == KTEXDataFormat.DXT3 || m_DataFormat == KTEXDataFormat.DXT3M)
                    WriteDXT3(i, mipmaps[i]);
                if (m_DataFormat == KTEXDataFormat.DXT5 || m_DataFormat == KTEXDataFormat.DXT5M)
                    WriteDXT5(i, mipmaps[i]);
            }

            Console.ReadLine();
        }


        static void WriteDXT1(int i, mipmap mm)
        {
            Console.WriteLine("DXT1 File!");
            string outfile = m_FileInName.Replace(".tex", i + ".dds");

            if (File.Exists(outfile))
                File.Delete(outfile);

            m_FileOut = new BinaryWriter(File.Create(outfile));

            m_FileOut.Write(new byte[4] { 0x44, 0x44, 0x53, 0x20 }); // DDS_
            m_FileOut.Write((uint)124); // DDS Header Size
            m_FileOut.Write(new byte[4] { 0x07, 0x10, 0x00, 0x00 }); //DDSFLAGS: DDSD_CAPS, DDSD_HEIGHT, DDSD_WIDTH, DDSD_PIXELFORMAT
            m_FileOut.Write((uint)mm.height); // Height
            m_FileOut.Write((uint)mm.width); // Width
            m_FileOut.Write((uint)0); // Pitch Or Linear Size
            m_FileOut.Write((uint)0); // Depth
            m_FileOut.Write((uint)0); // Mipmap Count
            m_FileOut.Write(new byte[4 * 11]); // Reserve 1.

            m_FileOut.Write((uint)32); // dwSize
            m_FileOut.Write((uint)4); // dwFlags
            m_FileOut.Write(Encoding.ASCII.GetBytes("DXT1")); // dwFourCC
            m_FileOut.Write((uint)0); // dwRGBBitCount
            m_FileOut.Write((uint)0); // dwRBitMask
            m_FileOut.Write((uint)0); // dwGBitMask
            m_FileOut.Write((uint)0); // dwBBitMask
            m_FileOut.Write((uint)0); // dwABitMask
            m_FileOut.Write(new byte[4] { 0, 0x10, 0, 0 }); // dwCaps1
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps2
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps3
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps4
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwReserved2

            byte[] ImageData = m_FileIn.ReadBytes((int)mm.size);
            m_FileOut.Write(ImageData);

            m_FileOut.Close();
        }

        static void WriteDXT3(int i, mipmap mm)
        {
            Console.WriteLine("DXT3 File!");
            string outfile = m_FileInName.Replace(".tex", i + ".dds");

            if (File.Exists(outfile))
                File.Delete(outfile);

            m_FileOut = new BinaryWriter(File.Create(outfile));

            m_FileOut.Write(new byte[4] { 0x44, 0x44, 0x53, 0x20 }); // DDS_
            m_FileOut.Write((uint)124); // DDS Header Size
            m_FileOut.Write(new byte[4] { 0x07, 0x10, 0x00, 0x00 }); //DDSFLAGS: DDSD_CAPS, DDSD_HEIGHT, DDSD_WIDTH, DDSD_PIXELFORMAT
            m_FileOut.Write((uint)mm.height); // Height
            m_FileOut.Write((uint)mm.width); // Width
            m_FileOut.Write((uint)0); // Pitch Or Linear Size
            m_FileOut.Write((uint)0); // Depth
            m_FileOut.Write((uint)0); // Mipmap Count
            m_FileOut.Write(new byte[4 * 11]); // Reserve 1.

            m_FileOut.Write((uint)32); // dwSize
            m_FileOut.Write((uint)4); // dwFlags
            m_FileOut.Write(Encoding.ASCII.GetBytes("DXT3")); // dwFourCC
            m_FileOut.Write((uint)0); // dwRGBBitCount
            m_FileOut.Write((uint)0); // dwRBitMask
            m_FileOut.Write((uint)0); // dwGBitMask
            m_FileOut.Write((uint)0); // dwBBitMask
            m_FileOut.Write((uint)0); // dwABitMask
            m_FileOut.Write(new byte[4] { 0, 0x10, 0, 0 }); // dwCaps1
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps2
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps3
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps4
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwReserved2

            byte[] ImageData = m_FileIn.ReadBytes((int)mm.size);
            m_FileOut.Write(ImageData);

            m_FileOut.Close();
        }

        static void WriteDXT5(int i, mipmap mm)
        {
            Console.WriteLine("DXT5 File!");
            string outfile = m_FileInName.Replace(".tex", i + ".dds");

            if (File.Exists(outfile))
                File.Delete(outfile);

            m_FileOut = new BinaryWriter(File.Create(outfile));

            m_FileOut.Write(new byte[4] { 0x44, 0x44, 0x53, 0x20 }); // DDS_
            m_FileOut.Write((uint)124); // DDS Header Size
            m_FileOut.Write(new byte[4] { 0x07, 0x10, 0x00, 0x00 }); //DDSFLAGS: DDSD_CAPS, DDSD_HEIGHT, DDSD_WIDTH, DDSD_PIXELFORMAT
            m_FileOut.Write((uint)mm.height); // Height
            m_FileOut.Write((uint)mm.width); // Width
            m_FileOut.Write((uint)0); // Pitch Or Linear Size
            m_FileOut.Write((uint)0); // Depth
            m_FileOut.Write((uint)0); // Mipmap Count
            m_FileOut.Write(new byte[4 * 11]); // Reserve 1.

            m_FileOut.Write((uint)32); // dwSize
            m_FileOut.Write((uint)4); // dwFlags
            m_FileOut.Write(Encoding.ASCII.GetBytes("DXT5")); // dwFourCC
            m_FileOut.Write((uint)0); // dwRGBBitCount
            m_FileOut.Write((uint)0); // dwRBitMask
            m_FileOut.Write((uint)0); // dwGBitMask
            m_FileOut.Write((uint)0); // dwBBitMask
            m_FileOut.Write((uint)0); // dwABitMask
            m_FileOut.Write(new byte[4] { 0, 0x10, 0, 0 }); // dwCaps1
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps2
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps3
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps4
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwReserved2

            byte[] ImageData = m_FileIn.ReadBytes((int)mm.size);
            m_FileOut.Write(ImageData);

            m_FileOut.Close();
        }

        static void WriteARGB(int i, mipmap mm)
        {
            Console.WriteLine("RAW File!");
            string outfile = m_FileInName.Replace(".tex", i + ".png");

            Bitmap pt = new Bitmap((int)mm.width, (int)mm.height);

            for (int y = 0; y < mm.height; y++)
                for (int x = 0; x < mm.width; x++) {
                    byte r = m_FileIn.ReadByte();
                    byte g = m_FileIn.ReadByte();
                    byte b = m_FileIn.ReadByte();
                    byte a = m_FileIn.ReadByte();
                    pt.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }

            pt.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pt.Save(outfile, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

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
using System.IO;
using System.Linq;
using System.Text;

namespace KleiLib
{
    public class BuildFile
    {

        /*
#BUILD format 5
# 'BILD'
# Version (int)
# total symbols;
# total frames;
# build name (int, string)
# num materials
#   material texture name (int, string)
#for each symbol:
#   symbol hash (int)
#   num frames (int)
#       frame num (int)
#       frame duration (int)
#       bbox x,y,w,h (floats)
#       vb start index (int)
#       num verts (int)

# num vertices (int)
#   x,y,z,u,v,w (all floats)
*/

        public readonly char[] BILDHeader = new char[] { 'B', 'I', 'L', 'D' };

        public uint BuildVersion;
        public uint TotalSymbols;
        public uint TotalFrames;
        public uint TotalAtlases;
        public uint TotalVerticies;
        public string BuildName;

        public string[] Atlases;

        public struct Symbol
        {
            public int Hash;
            public uint NumberOfFrames;
            public Frame[] Frames;
        }

        public struct Frame
        {
            public int FrameNumber;
            public int Duration;

            public float X;
            public float Y;
            public float W;
            public float H;

            public int VBStartIndex;
            public int NumberOfVerts;
        }

        public struct Vertex
        {
            public float X;
            public float Y;
            public float Z;
            public float U;
            public float V;
            public float W;
        }

        public Symbol[] Symbols;
        public Vertex[] Verticies;

        public BuildFile(Stream inStream)
        {
            using (var reader = new BinaryReader(inStream))
            {
                if (!reader.ReadChars(4).SequenceEqual(BILDHeader))
                    throw new Exception("The first 4 bytes do not match 'BILD'.");

                BuildVersion = reader.ReadUInt32();
                TotalSymbols = reader.ReadUInt32();
                TotalFrames = reader.ReadUInt32();
                BuildName = Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32()));
                TotalAtlases = reader.ReadUInt32();

                Atlases = new string[TotalAtlases];
                for (var i = 0; i < TotalAtlases; i++)
                    Atlases[i] = (Encoding.ASCII.GetString(reader.ReadBytes(reader.ReadInt32())));

                Symbols = new Symbol[TotalSymbols];
                for (var i = 0; i < TotalSymbols; i++)
                {
                    var symbol = new Symbol();

                    symbol.Hash = reader.ReadInt32();
                    symbol.NumberOfFrames = reader.ReadUInt32();
                    symbol.Frames = new Frame[symbol.NumberOfFrames];

                    for (var j = 0; j < symbol.NumberOfFrames; j++)
                    {
                        var frame = new Frame();

                        frame.FrameNumber = reader.ReadInt32();
                        frame.Duration = reader.ReadInt32();

                        frame.X = reader.ReadSingle();
                        frame.Y = reader.ReadSingle();
                        frame.W = reader.ReadSingle();
                        frame.H = reader.ReadSingle();

                        frame.VBStartIndex = reader.ReadInt32();
                        frame.NumberOfVerts = reader.ReadInt32();

                        symbol.Frames[j] = frame;
                    }

                    Symbols[i] = symbol;
                }

                TotalVerticies = reader.ReadUInt32();
                Verticies = new Vertex[TotalVerticies];
                for (var i = 0; i < TotalVerticies; i++)
                {
                    var vertex = new Vertex();

                    vertex.X = reader.ReadSingle();
                    vertex.Y = reader.ReadSingle();
                    vertex.Z = reader.ReadSingle(); // always 0.
                    vertex.U = reader.ReadSingle();
                    vertex.V = reader.ReadSingle();
                    vertex.W = reader.ReadSingle(); // always 0.

                    Verticies[i] = vertex;
                }
            }
        }
    }
}

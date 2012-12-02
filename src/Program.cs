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
            DTX,
            DTX5,
            RAW,
            Unknown
        }

        static string m_FileInName;
        static uint m_Width;
        static uint m_Height;

        static BinaryReader m_FileIn;
        static BinaryWriter m_FileOut;

        static KTEXDataFormat m_DataFormat;
        static int m_ImageDataSize;

        static void DoError(string str) {
            Console.WriteLine(str);
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
                DoError("Usage: texdecompress file.tex");

            m_FileInName = args[0];
            m_FileIn = new BinaryReader(new FileStream(m_FileInName, FileMode.Open));

            if (m_FileIn.ReadByte() != 'K' || m_FileIn.ReadByte() != 'T' || m_FileIn.ReadByte() != 'E' || m_FileIn.ReadByte() != 'X')
                DoError("Header doesn't match KTEX! Sorry. :(");

            byte[] dataformat = m_FileIn.ReadBytes(4);

            if (dataformat[0] == 0x50 && dataformat[1] == 0xE2 && dataformat[2] == 0xFF && dataformat[3] == 0xFF)
                m_DataFormat = KTEXDataFormat.DTX5;
            else if (dataformat[0] == 0x50 && dataformat[1] == 0xF8 && dataformat[2] == 0xFF && dataformat[3] == 0xFF)
                m_DataFormat = KTEXDataFormat.DTX;
            else if (dataformat[0] == 0x50 && dataformat[1] == 0xEE && dataformat[2] == 0xFF && dataformat[3] == 0xFF)
                m_DataFormat = KTEXDataFormat.DTX;
            else if (dataformat[0] == 0x60 && dataformat[1] == 0xE2 && dataformat[2] == 0xFF && dataformat[3] == 0xFF)
                m_DataFormat = KTEXDataFormat.RAW;
            else
                m_DataFormat = KTEXDataFormat.Unknown;

            m_Width = m_FileIn.ReadUInt16();
            m_Height = m_FileIn.ReadUInt16();

            // unknown bytes, everything seems to work fine without them though
            m_FileIn.ReadBytes(6);

            // 18 is the size of the KTEX Header
            m_ImageDataSize = (int)m_FileIn.BaseStream.Length - 18;

            Console.WriteLine("Image Dimensions: (" + m_Width + ", " + m_Height + ")");
            Console.WriteLine("Image Size: " + m_ImageDataSize + " bytes");

            if (m_DataFormat == KTEXDataFormat.DTX5)
                WriteDTX5();
            else if (m_DataFormat == KTEXDataFormat.DTX)
                WriteDTX();
            else if (m_DataFormat == KTEXDataFormat.RAW)
                WriteRAW();
            else
                Console.WriteLine("Unknown data format. Soorrry!");

            /*
             * (format[0] == 0x50 && format[1] == 0xF0 && format[2] == 0xFF && format[3] == 0xFF)
             * (format[0] == 0x50 && format[1] == 0xEE && format[2] == 0xFF && format[3] == 0xFF)
            */
        }


        static void WriteDTX()
        {
            Console.WriteLine("DXT? File!");
            string outfile = m_FileInName.Replace(".tex", ".dds");

            if (File.Exists(outfile))
                File.Delete(outfile);

            m_FileOut = new BinaryWriter(File.Create(outfile));

            m_FileOut.Write(new byte[4] { 0x44, 0x44, 0x53, 0x20 }); // DDS_
            m_FileOut.Write((uint)124); // DDS Header Size
            m_FileOut.Write(new byte[4] { 0x07, 0x10, 0x00, 0x00 }); //DDSFLAGS: DDSD_CAPS, DDSD_HEIGHT, DDSD_WIDTH, DDSD_PIXELFORMAT
            m_FileOut.Write(m_Height); // Height
            m_FileOut.Write(m_Width); // Width
            m_FileOut.Write((uint)0); // Pitch Or Linear Size
            m_FileOut.Write((uint)0); // Depth
            m_FileOut.Write((uint)0); // Mipmap Count
            m_FileOut.Write(new byte[4 * 11]); // Reserve 1.

            uint dwflags = 0x00000041;

            m_FileOut.Write((uint)32); // dwSize
            m_FileOut.Write(dwflags); // dwFlags
            m_FileOut.Write(Encoding.ASCII.GetBytes("DXT5")); // dwFourCC
            m_FileOut.Write((uint)32); // dwRGBBitCount
            m_FileOut.Write((uint)0xff0000); // dwRBitMask 
            m_FileOut.Write((uint)0xff00); // dwGBitMask
            m_FileOut.Write((uint)0xff); // dwBBitMask
            m_FileOut.Write((uint)0xff000000); // dwABitMask
            m_FileOut.Write(new byte[4] { 0, 0x10, 0, 0 }); // dwCaps1
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps2
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps3
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwCaps4
            m_FileOut.Write(new byte[4] { 0, 0, 0, 0 }); // dwReserved2

            byte[] ImageData = m_FileIn.ReadBytes(m_ImageDataSize);
            m_FileOut.Write(ImageData);
        }

        static void WriteDTX5()
        {
            Console.WriteLine("DXT5 File!");
            string outfile = m_FileInName.Replace(".tex", ".dds");

            if (File.Exists(outfile))
                File.Delete(outfile);

            m_FileOut = new BinaryWriter(File.Create(outfile));

            m_FileOut.Write(new byte[4] { 0x44, 0x44, 0x53, 0x20 }); // DDS_
            m_FileOut.Write((uint)124); // DDS Header Size
            m_FileOut.Write(new byte[4] { 0x07, 0x10, 0x00, 0x00 }); //DDSFLAGS: DDSD_CAPS, DDSD_HEIGHT, DDSD_WIDTH, DDSD_PIXELFORMAT
            m_FileOut.Write(m_Height); // Height
            m_FileOut.Write(m_Width); // Width
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

            byte[] ImageData = m_FileIn.ReadBytes(m_ImageDataSize);
            m_FileOut.Write(ImageData);
        }

        static void WriteRAW()
        {
            Console.WriteLine("RAW File!");
            string outfile = m_FileInName.Replace(".tex", ".png");

            Bitmap pt = new Bitmap((int)m_Width, (int)m_Height);

            for (int y = 0; y < m_Height; y++)
                for (int x = 0; x < m_Width; x++) {
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

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
using System.Drawing;
using System.IO;
using System.Linq;
using KleiLib;
using SquishNET;

using System.Collections.Generic;
using System.Xml;

namespace TEXTool
{
    class KleiTextureAtlasElement
    {
        public string Name { get; set; }
        public int ImgHmin { get; set; }
        public int ImgHmax { get; set; }
        public int ImgVmin { get; set; }
        public int ImgVmax { get; set; }

        public KleiTextureAtlasElement(string name, int u1, int u2, int v1, int v2)
        {
            this.Name = name;
            this.ImgHmin = u1;
            this.ImgHmax = u2;
            this.ImgVmin = v1;
            this.ImgVmax = v2;
        }
    }

    public class FileOpenedEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string Platform { get; set; }
        public string Format   { get; set; }
        public string Size     { get; set; }
        public string Mipmaps  { get; set; }
        public string TexType  { get; set; }
        public bool   PreCave  { get; set; }

        public FileOpenedEventArgs(string filename) {
            this.FileName = filename;
        }
    }

    public class FileRawImageEventArgs : EventArgs
    {
        public Bitmap Image { get; set; }

        public FileRawImageEventArgs(Bitmap image)
        {
            this.Image = image;
        }
    }

    public delegate void FileOpenedEventHandler(object sender, FileOpenedEventArgs e);
    public delegate void FileRawImageEventHandler(object sender, FileRawImageEventArgs e);

    public class TEXTool
    {
        public List<KleiTextureAtlasElement> AtlasElements = new List<KleiTextureAtlasElement>();

        public TEXFile CurrentFile;
        public Bitmap CurrentFileRaw;

        public event FileOpenedEventHandler FileOpened;
        public event FileRawImageEventHandler FileRawImage;

        #region Util

        public static class EnumHelper<T>
        {
            public static string GetEnumDescription(string value)
            {
                Type type = typeof(T);
                var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

                if (name == null)
                {
                    return string.Empty;
                }
                var field = type.GetField(name);
                var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
            }

            public static T GetValueFromDescription(string description)
            {
                var type = typeof(T);
                if (!type.IsEnum) throw new InvalidOperationException();
                foreach (var field in type.GetFields())
                {
                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attribute != null)
                    {
                        if (attribute.Description == description)
                            return (T)field.GetValue(null);
                    }
                    else
                    {
                        if (field.Name == description)
                            return (T)field.GetValue(null);
                    }
                }
                throw new ArgumentException("Not found.", "description");
            }
        }

        #endregion

        public void OpenFile(string filename, Stream stream)
        {
            CurrentFile = new TEXFile(stream);

            var EArgs = new FileOpenedEventArgs(filename);
            EArgs.Platform = ((TEXFile.Platform)CurrentFile.File.Header.Platform).ToString("F");
            EArgs.Format = ((TEXFile.PixelFormat)CurrentFile.File.Header.PixelFormat).ToString("F");
            EArgs.Mipmaps = CurrentFile.File.Header.NumMips.ToString();
            EArgs.PreCave = CurrentFile.IsPreCaveUpdate();
            EArgs.TexType = EnumHelper<TEXFile.TextureType>.GetEnumDescription(((TEXFile.TextureType)CurrentFile.File.Header.TextureType).ToString());

            var mipmap = CurrentFile.GetMainMipmap();

            EArgs.Size = mipmap.Width + "x" + mipmap.Height;

            OnOpenFile(EArgs);

            byte[] argbData;

            switch ((TEXFile.PixelFormat)CurrentFile.File.Header.PixelFormat)
            {
                case TEXFile.PixelFormat.DXT1:
                    argbData = Squish.DecompressImage(mipmap.Data, mipmap.Width, mipmap.Height, SquishFlags.Dxt1);
                    break;
                case TEXFile.PixelFormat.DXT3:
                    argbData = Squish.DecompressImage(mipmap.Data, mipmap.Width, mipmap.Height, SquishFlags.Dxt3);
                    break;
                case TEXFile.PixelFormat.DXT5:
                    argbData = Squish.DecompressImage(mipmap.Data, mipmap.Width, mipmap.Height, SquishFlags.Dxt5);
                    break;
                case TEXFile.PixelFormat.ARGB:
                    argbData = mipmap.Data;
                    break;
                default:
                    throw new Exception("Unknown pixel format?");
            }

            string atlasExt = "xml";
            FileInfo fileInfo = new FileInfo(filename);
            string fileDir = fileInfo.DirectoryName;
            string fileNameWithoutExt = fileInfo.Name.Replace(fileInfo.Extension, "");
            string atlasDataPath = fileDir + fileNameWithoutExt + "." + atlasExt;
            if (File.Exists(atlasDataPath))
            {
                ReadAtlasData(atlasDataPath, mipmap.Width, mipmap.Height);
            }

            var imgReader = new BinaryReader(new MemoryStream(argbData));

            Bitmap pt = new Bitmap((int)mipmap.Width, (int)mipmap.Height);

            for (int y = 0; y < mipmap.Height; y++)
                for (int x = 0; x < mipmap.Width; x++)
                {
                    byte r = imgReader.ReadByte();
                    byte g = imgReader.ReadByte();
                    byte b = imgReader.ReadByte();
                    byte a = imgReader.ReadByte();
                    pt.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }

            pt.RotateFlip(RotateFlipType.RotateNoneFlipY);

            CurrentFileRaw = pt;

            OnRawImage(new FileRawImageEventArgs(pt));
        }

        private void ReadAtlasData(string path, int mipmapWidth, int mipmapHeight)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                XmlNode xNodeElements = xDoc.SelectSingleNode("Atlas/Elements");
                foreach (XmlNode xChild in xNodeElements.ChildNodes)
                {
                    string name = xChild.Attributes.GetNamedItem("name").Value;
                    double u1 = Convert.ToDouble(xChild.Attributes.GetNamedItem("u1").Value.Replace(".", ","));
                    double u2 = Convert.ToDouble(xChild.Attributes.GetNamedItem("u2").Value.Replace(".", ","));
                    double v1 = Convert.ToDouble(xChild.Attributes.GetNamedItem("v1").Value.Replace(".", ","));
                    double v2 = Convert.ToDouble(xChild.Attributes.GetNamedItem("v2").Value.Replace(".", ","));

                    int imgHmin, imgHmax, imgVmin, imgVmax;
                    double margin = 0.5;
                    imgHmin = Convert.ToInt16(u1 * mipmapWidth - margin);
                    imgHmax = Convert.ToInt16(u2 * mipmapWidth - margin);
                    imgVmin = Convert.ToInt16(v1 * mipmapHeight - margin);
                    imgVmax = Convert.ToInt16(v2 * mipmapHeight - margin);

                    AtlasElements.Add(new KleiTextureAtlasElement(name, imgHmin, imgHmax, imgVmin, imgVmax));
                }
            }
            catch (Exception e)
            {
                AtlasElements.Clear();
                Console.WriteLine(e.Message);
            }
        }



        public void SaveFile(string FilePath)
        {
            CurrentFileRaw.Save(FilePath);
        }

        public void SaveFile(Stream fileStream)
        {
            CurrentFileRaw.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
        }

        protected virtual void OnOpenFile(FileOpenedEventArgs args)
        {
            FileOpenedEventHandler handler = FileOpened;
            if (handler != null)
            {
                ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;

                if (target != null && target.InvokeRequired)
                    target.Invoke(handler, new object[] { this, args });
                else
                    handler(this, args);
            }
        }

        protected virtual void OnRawImage(FileRawImageEventArgs args)
        {
            FileRawImageEventHandler handler = FileRawImage;
            if (handler != null)
            {
                ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;

                if (target != null && target.InvokeRequired)
                    target.Invoke(handler, new object[] { this, args });
                else
                    handler(this, args);
            }
        }
    }
}

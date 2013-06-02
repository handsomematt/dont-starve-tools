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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KleiLib;
using SquishNET;

namespace TEXCreator
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
            PopulateComboboxes();
        }

        #region Conversion

        private void StartConversion()
        {
            foreach (string fileName in selectedTexturesListBox.Items)
            {
                var output = outputDirectoryTextBox.Text + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(fileName) + ".tex";
                ConvertPNGToTex(fileName, new FileStream(output, FileMode.OpenOrCreate));

                logListBox.Items.Add("Compressed: " + output);
                System.Threading.Thread.Sleep(1);
            }
        }

        struct Mipmap {
            public ushort Width;
            public ushort Height;
            public ushort Pitch;
            public byte[] ARGBData;

            public Mipmap(ushort w, ushort h, ushort p, byte[] d) { Width = w; Height = h; Pitch = p; ARGBData = d; }
        }

        private void ConvertPNGToTex(string inputFile, FileStream outputStream)
        {
            TEXFile.PixelFormat PixelFormat = (TEXFile.PixelFormat)Enum.Parse(typeof(TEXFile.PixelFormat), this.pixelFormatComboBox.Text);
            InterpolationMode interpolationMode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode), this.mipmapFilterComboBox.Text);

            Bitmap inputImage = (Bitmap)Bitmap.FromFile(inputFile);
            inputImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

            bool GenerateMipmaps = generateMipmapsCheckBox.Checked;
            List<Mipmap> Mipmaps = new List<Mipmap>();

            bool preMultiplyAlpha = preMultiplyAlphaCheckBox.Checked;

            Mipmaps.Add(GenerateMipmap(inputImage, PixelFormat, preMultiplyAlpha));

            if (GenerateMipmaps) {
                var width = inputImage.Width;
                var height = inputImage.Height;

                while (Math.Max(width, height) > 1)
                {
                    width = Math.Max(1, width >> 1);
                    height = Math.Max(1, height >> 1);

                    Mipmaps.Add(GenerateMipmap(inputImage, PixelFormat, width, height, interpolationMode, preMultiplyAlpha));
                }
            }

            TEXFile outputTEXFile = new TEXFile();

            outputTEXFile.File.Header.Platform = 0;
            outputTEXFile.File.Header.PixelFormat = (uint)PixelFormat;
            outputTEXFile.File.Header.TextureType = (uint)EnumHelper<TEXFile.TextureType>.GetValueFromDescription(this.textureTypeComboBox.Text);
            outputTEXFile.File.Header.NumMips = (uint)Mipmaps.Count;
            outputTEXFile.File.Header.Flags = 0;

            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);

            foreach (Mipmap mip in Mipmaps)
            {
                writer.Write(mip.Width);
                writer.Write(mip.Height);
                writer.Write(mip.Pitch);
                writer.Write((uint)mip.ARGBData.Length);
            }

            foreach (Mipmap mip in Mipmaps)
                writer.Write(mip.ARGBData);

            writer.Close();

            outputTEXFile.File.Raw = ms.ToArray();

            outputTEXFile.SaveFile(outputStream);
        }

        private Mipmap GenerateMipmap(Bitmap inputImage, TEXFile.PixelFormat pixelFormat, bool preMultiplyAlpha)
        {
            byte[] rgba = new byte[inputImage.Width * inputImage.Height * 4];

            for (int y = 0; y < inputImage.Height; y++)
                for (int x = 0; x < inputImage.Width; x++)
                {
                    Color c = inputImage.GetPixel(x, y);

                    if (preMultiplyAlpha) {
                        float alphamod = (float)c.A / 255.0f; // Normalize.

                        var newR = (byte)(c.R * alphamod);
                        var newG = (byte)(c.G * alphamod);
                        var newB = (byte)(c.B * alphamod);

                        c = Color.FromArgb(c.A, newR, newG, newB);
                    }

                    rgba[y * inputImage.Width * 4 + x * 4 + 0] = c.R;
                    rgba[y * inputImage.Width * 4 + x * 4 + 1] = c.G;
                    rgba[y * inputImage.Width * 4 + x * 4 + 2] = c.B;
                    rgba[y * inputImage.Width * 4 + x * 4 + 3] = c.A;
                }

            byte[] finalImageData = null;

            switch (pixelFormat)
            {
                case TEXFile.PixelFormat.DXT1:
                    finalImageData = Squish.CompressImage(rgba, inputImage.Width, inputImage.Height, SquishFlags.Dxt1);
                    break;
                case TEXFile.PixelFormat.DXT3:
                    finalImageData = Squish.CompressImage(rgba, inputImage.Width, inputImage.Height, SquishFlags.Dxt3);
                    break;
                case TEXFile.PixelFormat.DXT5:
                    finalImageData = Squish.CompressImage(rgba, inputImage.Width, inputImage.Height, SquishFlags.Dxt5);
                    break;
                case TEXFile.PixelFormat.ARGB:
                    finalImageData = rgba;
                    break;
            }

            var mipmap = new Mipmap();
            mipmap.Width = (ushort)inputImage.Width;
            mipmap.Height = (ushort)inputImage.Height;
            mipmap.Pitch = 0;
            mipmap.ARGBData = finalImageData;

            return mipmap;
        }

        private Mipmap GenerateMipmap(Bitmap inputImage, TEXFile.PixelFormat pixelFormat, int width, int height, InterpolationMode mode, bool preMultiplyAlpha)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = mode;
                g.DrawImage(inputImage, 0, 0, width, height);
            }

            return GenerateMipmap(b, pixelFormat, preMultiplyAlpha);
        }

        #endregion

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

        #region Population

        private void PopulateComboboxes()
        {
            foreach (TEXFile.PixelFormat format in Enum.GetValues(typeof(TEXFile.PixelFormat)))
                if ( format != TEXFile.PixelFormat.Unknown )
                    pixelFormatComboBox.Items.Add(format);
            pixelFormatComboBox.Text = TEXFile.PixelFormat.DXT5.ToString(); // Default value of DXT5.

            foreach (TEXFile.TextureType textype in Enum.GetValues(typeof(TEXFile.TextureType)))
                textureTypeComboBox.Items.Add(EnumHelper<TEXFile.TextureType>.GetEnumDescription(textype.ToString()));
            textureTypeComboBox.Text = EnumHelper<TEXFile.TextureType>.GetEnumDescription(TEXFile.TextureType.OneD.ToString());

            foreach (InterpolationMode mode in Enum.GetValues(typeof(InterpolationMode)))
                if ( mode != InterpolationMode.Invalid )
                    mipmapFilterComboBox.Items.Add(mode);
            mipmapFilterComboBox.Text = InterpolationMode.Default.ToString();
        }

        #endregion

        #region Dialogs

        private void AddFileDialog()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "All Supported Images (*.bmp;*.dib;*.rle;*.gif;*.jpg;*.png)|*.bmp;*.dib;*.rle;*.gif;*.jpg;*.png|Bitmaps (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle|Graphics Interchange Format (*.gif)|*.gif|Joint Photographic Experts (*.jpg)|*.jpg|Portable Network Graphics (*.png)|*.png|All Files (*.*)|*.*";
                dialog.DefaultExt = "png";
                dialog.Multiselect = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (string file in dialog.FileNames)
                        selectedTexturesListBox.Items.Add(file);
                }
            }
        }

        private void OutputDirectorySearchDialog()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    outputDirectoryTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        #endregion

        #region Form Control Events.

        private void convertButton_Click(object sender, EventArgs e)
        {
            StartConversion();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddFileDialog();
        }

        private void outputDirectorySearchButton_Click(object sender, EventArgs e)
        {
            OutputDirectorySearchDialog();
        }

        #endregion
    }
}

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
using System.Reflection;
using System.Windows.Forms;

namespace TEXTool
{
    public partial class MainForm : Form
    {
        public TEXTool Tool;

        public MainForm()
        {
            Tool = new TEXTool();
            Tool.FileOpened += new FileOpenedEventHandler(TEXTool_FileOpened);
            Tool.FileRawImage += new FileRawImageEventHandler(tool_FileRawImage);

            InitializeComponent();
            FillZoomLevelComboBox();
            versionToolStripLabel.Text = string.Format("Version: {0}", Assembly.GetEntryAssembly().GetName().Version);
        }

        #region

        void tool_FileRawImage(object sender, FileRawImageEventArgs e)
        {
            imageBox.Image = e.Image;
            zoomLevelToolStripComboBox.Text = string.Format("{0}%", imageBox.Zoom);
        }

        private void TEXTool_FileOpened(object sender, FileOpenedEventArgs e)
        {
            this.Text = String.Format("Klei Studio - TEXTool - [{0}]", e.FileName);
            this.formatToolStripStatusLabel.Text = String.Format("Format: {0}", e.Format);
            this.sizeToolStripStatusLabel.Text = String.Format("Size: {0}", e.Size);
            this.mipmapsToolStripStatusLabel.Text = String.Format("Mipmaps: {0}", e.Mipmaps);
            this.platformToolStripStatusLabel.Text = String.Format("Platform: {0}", e.Platform);
            this.textureTypeToolStripStatusLabel.Text = String.Format("Texture Type: {0}", e.TexType);

            if (e.PreCave)
                MessageBox.Show(@"Error, this is a pre 'Cave Update' TEX file. If you want to convert this, please use an older version of TEXTool or 'update' the file using the converter found in the offical thread.");
        }

        private void OpenFileDialog()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Klei Texture Files (*.tex)|*.tex|All Files (*.*)|*.*";
                dialog.DefaultExt = "tex";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Tool.OpenFile(dialog.FileName, dialog.OpenFile());
                }
            }
        }

        private void SaveFileDialog()
        {
            if (Tool.CurrentFile == null)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "All Supported Images (*.bmp;*.dib;*.rle;*.gif;*.jpg;*.png)|*.bmp;*.dib;*.rle;*.gif;*.jpg;*.png|Bitmaps (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle|Graphics Interchange Format (*.gif)|*.gif|Joint Photographic Experts (*.jpg)|*.jpg|Portable Network Graphics (*.png)|*.png|All Files (*.*)|*.*";
                dialog.DefaultExt = "png";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Tool.SaveFile(dialog.FileName);
                }
            }
        }

        private void FillZoomLevelComboBox()
        {
            zoomLevelToolStripComboBox.Items.Clear();

            foreach (int zoom in imageBox.ZoomLevels)
                zoomLevelToolStripComboBox.Items.Add(string.Format("{0}%", zoom));
        }

        #endregion

        #region ToolStrip Buttons

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        private void fitToolStripButton_Click(object sender, EventArgs e)
        {
            this.imageBox.ZoomToFit();
        }

        private void zoomInToolStripButton_Click(object sender, EventArgs e)
        {
            this.imageBox.ZoomIn();
        }

        private void zoomOutToolStripButton_Click(object sender, EventArgs e)
        {
            this.imageBox.ZoomOut();
        }

        private void infoToolStripButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dev-zilla.net/kleistudio/");
        }

        #endregion

        #region Misc Form Event Handlers

        private void imageBox1_ZoomLevelsChanged(object sender, EventArgs e)
        {
            FillZoomLevelComboBox();
        }

        private void imageBox1_ZoomChanged(object sender, EventArgs e)
        {
            zoomLevelToolStripComboBox.Text = string.Format("{0}%", imageBox.Zoom);
        }

        #endregion

        #region Hotkeys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData) {
                case Keys.Control | Keys.O:
                    OpenFileDialog();
                    break;
                case Keys.Control | Keys.S:
                    SaveFileDialog();
                    break;
                case Keys.Control | Keys.Add:
                    imageBox.ZoomIn();
                    break;
                case Keys.Control | Keys.Subtract:
                    imageBox.ZoomOut();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        #endregion
    }
}

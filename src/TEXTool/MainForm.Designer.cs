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

namespace TEXTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.formatToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mipmapsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.platformToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textureTypeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageBox = new Cyotek.Windows.Forms.ImageBox();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.fitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomLevelToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.infoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.versionToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.imageBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(694, 370);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(694, 417);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripStatusLabel,
            this.sizeToolStripStatusLabel,
            this.mipmapsToolStripStatusLabel,
            this.platformToolStripStatusLabel,
            this.textureTypeToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // formatToolStripStatusLabel
            // 
            this.formatToolStripStatusLabel.Name = "formatToolStripStatusLabel";
            this.formatToolStripStatusLabel.Size = new System.Drawing.Size(41, 17);
            this.formatToolStripStatusLabel.Text = "Format";
            // 
            // sizeToolStripStatusLabel
            // 
            this.sizeToolStripStatusLabel.Name = "sizeToolStripStatusLabel";
            this.sizeToolStripStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.sizeToolStripStatusLabel.Text = "Size";
            // 
            // mipmapsToolStripStatusLabel
            // 
            this.mipmapsToolStripStatusLabel.Name = "mipmapsToolStripStatusLabel";
            this.mipmapsToolStripStatusLabel.Size = new System.Drawing.Size(48, 17);
            this.mipmapsToolStripStatusLabel.Text = "Mipmaps";
            // 
            // platformToolStripStatusLabel
            // 
            this.platformToolStripStatusLabel.Name = "platformToolStripStatusLabel";
            this.platformToolStripStatusLabel.Size = new System.Drawing.Size(47, 17);
            this.platformToolStripStatusLabel.Text = "Platform";
            // 
            // textureTypeToolStripStatusLabel
            // 
            this.textureTypeToolStripStatusLabel.Name = "textureTypeToolStripStatusLabel";
            this.textureTypeToolStripStatusLabel.Size = new System.Drawing.Size(49, 17);
            this.textureTypeToolStripStatusLabel.Text = "TexType";
            // 
            // imageBox
            // 
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(694, 370);
            this.imageBox.TabIndex = 3;
            this.imageBox.ZoomChanged += new System.EventHandler(this.imageBox_ZoomChanged);
            this.imageBox.ZoomLevelsChanged += new System.EventHandler(this.imageBox_ZoomLevelsChanged);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.fitToolStripButton,
            this.zoomInToolStripButton,
            this.zoomOutToolStripButton,
            this.toolStripSeparator1,
            this.zoomLevelToolStripComboBox,
            this.infoToolStripButton,
            this.versionToolStripLabel,
            this.toolStripComboBox1});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(694, 25);
            this.mainToolStrip.Stretch = true;
            this.mainToolStrip.TabIndex = 1;
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::TEXTool.Properties.Resources.folder;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::TEXTool.Properties.Resources.disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // fitToolStripButton
            // 
            this.fitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fitToolStripButton.Image = global::TEXTool.Properties.Resources.magnifier;
            this.fitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitToolStripButton.Name = "fitToolStripButton";
            this.fitToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fitToolStripButton.Text = "Zoom To Fit";
            this.fitToolStripButton.Click += new System.EventHandler(this.fitToolStripButton_Click);
            // 
            // zoomInToolStripButton
            // 
            this.zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInToolStripButton.Image = global::TEXTool.Properties.Resources.magnifier_zoom_in;
            this.zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInToolStripButton.Name = "zoomInToolStripButton";
            this.zoomInToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInToolStripButton.Text = "Zoom In";
            this.zoomInToolStripButton.Click += new System.EventHandler(this.zoomInToolStripButton_Click);
            // 
            // zoomOutToolStripButton
            // 
            this.zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutToolStripButton.Image = global::TEXTool.Properties.Resources.magifier_zoom_out;
            this.zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutToolStripButton.Name = "zoomOutToolStripButton";
            this.zoomOutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutToolStripButton.Text = "Zoom Out";
            this.zoomOutToolStripButton.Click += new System.EventHandler(this.zoomOutToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomLevelToolStripComboBox
            // 
            this.zoomLevelToolStripComboBox.Name = "zoomLevelToolStripComboBox";
            this.zoomLevelToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // infoToolStripButton
            // 
            this.infoToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoToolStripButton.Image = global::TEXTool.Properties.Resources.information;
            this.infoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoToolStripButton.Name = "infoToolStripButton";
            this.infoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.infoToolStripButton.Text = "Info";
            this.infoToolStripButton.Click += new System.EventHandler(this.infoToolStripButton_Click);
            // 
            // versionToolStripLabel
            // 
            this.versionToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.versionToolStripLabel.Name = "versionToolStripLabel";
            this.versionToolStripLabel.Size = new System.Drawing.Size(42, 22);
            this.versionToolStripLabel.Text = "Version";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 417);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "KleiStudio - TEXTool";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel formatToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel sizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel mipmapsToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel platformToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel textureTypeToolStripStatusLabel;
        private Cyotek.Windows.Forms.ImageBox imageBox;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton fitToolStripButton;
        private System.Windows.Forms.ToolStripButton zoomInToolStripButton;
        private System.Windows.Forms.ToolStripButton zoomOutToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox zoomLevelToolStripComboBox;
        private System.Windows.Forms.ToolStripButton infoToolStripButton;
        private System.Windows.Forms.ToolStripLabel versionToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;


    }
}
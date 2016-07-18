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
            this.atlasElementsToolStrip = new System.Windows.Forms.ToolStrip();
            this.atlasElementsToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.atlasElementsCountToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementsCountIntToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.atlasElementsTitleToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementsListToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.atlasElementBorderColorToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementBorderColors = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.atlasElementWidthToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementWidthToolStrip = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementHeightToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementHeightToolStrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.atlasElementXToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementXToolStrip = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementYToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.atlasElementYToolStrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.atlasElementsToolStrip.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(748, 345);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(748, 417);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.atlasElementsToolStrip);
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
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
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
            this.imageBox.Size = new System.Drawing.Size(748, 345);
            this.imageBox.TabIndex = 3;
            this.imageBox.ZoomChanged += new System.EventHandler(this.imageBox_ZoomChanged);
            this.imageBox.ZoomLevelsChanged += new System.EventHandler(this.imageBox_ZoomLevelsChanged);
            this.imageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.imageBox_Paint);
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
            this.versionToolStripLabel});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(748, 25);
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
            this.zoomLevelToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.zoomLevelToolStripComboBox_SelectedIndexChanged);
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
            // atlasElementsToolStrip
            // 
            this.atlasElementsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.atlasElementsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atlasElementsToolStripLabel,
            this.toolStripSeparator2,
            this.atlasElementsCountToolStripLabel,
            this.atlasElementsCountIntToolStripLabel,
            this.toolStripSeparator3,
            this.atlasElementsTitleToolStripLabel,
            this.atlasElementsListToolStripComboBox,
            this.toolStripSeparator4,
            this.atlasElementBorderColorToolStripLabel,
            this.atlasElementBorderColors,
            this.toolStripSeparator7,
            this.atlasElementWidthToolStripLabel,
            this.atlasElementWidthToolStrip,
            this.atlasElementHeightToolStripLabel,
            this.atlasElementHeightToolStrip,
            this.toolStripSeparator5,
            this.atlasElementXToolStripLabel,
            this.atlasElementXToolStrip,
            this.atlasElementYToolStripLabel,
            this.atlasElementYToolStrip});
            this.atlasElementsToolStrip.Location = new System.Drawing.Point(0, 25);
            this.atlasElementsToolStrip.Name = "atlasElementsToolStrip";
            this.atlasElementsToolStrip.Size = new System.Drawing.Size(748, 25);
            this.atlasElementsToolStrip.Stretch = true;
            this.atlasElementsToolStrip.TabIndex = 2;
            // 
            // atlasElementsToolStripLabel
            // 
            this.atlasElementsToolStripLabel.Name = "atlasElementsToolStripLabel";
            this.atlasElementsToolStripLabel.Size = new System.Drawing.Size(81, 22);
            this.atlasElementsToolStripLabel.Text = "Atlas Elements:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // atlasElementsCountToolStripLabel
            // 
            this.atlasElementsCountToolStripLabel.Name = "atlasElementsCountToolStripLabel";
            this.atlasElementsCountToolStripLabel.Size = new System.Drawing.Size(40, 22);
            this.atlasElementsCountToolStripLabel.Text = "Count:";
            // 
            // atlasElementsCountIntToolStripLabel
            // 
            this.atlasElementsCountIntToolStripLabel.Name = "atlasElementsCountIntToolStripLabel";
            this.atlasElementsCountIntToolStripLabel.Size = new System.Drawing.Size(13, 22);
            this.atlasElementsCountIntToolStripLabel.Text = "0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // atlasElementsTitleToolStripLabel
            // 
            this.atlasElementsTitleToolStripLabel.Name = "atlasElementsTitleToolStripLabel";
            this.atlasElementsTitleToolStripLabel.Size = new System.Drawing.Size(54, 22);
            this.atlasElementsTitleToolStripLabel.Text = "Elements:";
            // 
            // atlasElementsListToolStripComboBox
            // 
            this.atlasElementsListToolStripComboBox.Enabled = false;
            this.atlasElementsListToolStripComboBox.Name = "atlasElementsListToolStripComboBox";
            this.atlasElementsListToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.atlasElementsListToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.atlasElementsListToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // atlasElementBorderColorToolStripLabel
            // 
            this.atlasElementBorderColorToolStripLabel.Name = "atlasElementBorderColorToolStripLabel";
            this.atlasElementBorderColorToolStripLabel.Size = new System.Drawing.Size(69, 22);
            this.atlasElementBorderColorToolStripLabel.Text = "Border color:";
            // 
            // atlasElementBorderColors
            // 
            this.atlasElementBorderColors.Enabled = false;
            this.atlasElementBorderColors.Name = "atlasElementBorderColors";
            this.atlasElementBorderColors.Size = new System.Drawing.Size(121, 25);
            this.atlasElementBorderColors.SelectedIndexChanged += new System.EventHandler(this.atlasElementBorderColors_SelectedIndexChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // atlasElementWidthToolStripLabel
            // 
            this.atlasElementWidthToolStripLabel.Name = "atlasElementWidthToolStripLabel";
            this.atlasElementWidthToolStripLabel.Size = new System.Drawing.Size(39, 22);
            this.atlasElementWidthToolStripLabel.Text = "Width:";
            // 
            // atlasElementWidthToolStrip
            // 
            this.atlasElementWidthToolStrip.Name = "atlasElementWidthToolStrip";
            this.atlasElementWidthToolStrip.Size = new System.Drawing.Size(13, 22);
            this.atlasElementWidthToolStrip.Text = "0";
            // 
            // atlasElementHeightToolStripLabel
            // 
            this.atlasElementHeightToolStripLabel.Name = "atlasElementHeightToolStripLabel";
            this.atlasElementHeightToolStripLabel.Size = new System.Drawing.Size(42, 22);
            this.atlasElementHeightToolStripLabel.Text = "Height:";
            // 
            // atlasElementHeightToolStrip
            // 
            this.atlasElementHeightToolStrip.Name = "atlasElementHeightToolStrip";
            this.atlasElementHeightToolStrip.Size = new System.Drawing.Size(13, 22);
            this.atlasElementHeightToolStrip.Text = "0";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // atlasElementXToolStripLabel
            // 
            this.atlasElementXToolStripLabel.Name = "atlasElementXToolStripLabel";
            this.atlasElementXToolStripLabel.Size = new System.Drawing.Size(17, 22);
            this.atlasElementXToolStripLabel.Text = "X:";
            // 
            // atlasElementXToolStrip
            // 
            this.atlasElementXToolStrip.Name = "atlasElementXToolStrip";
            this.atlasElementXToolStrip.Size = new System.Drawing.Size(13, 22);
            this.atlasElementXToolStrip.Text = "0";
            // 
            // atlasElementYToolStripLabel
            // 
            this.atlasElementYToolStripLabel.Name = "atlasElementYToolStripLabel";
            this.atlasElementYToolStripLabel.Size = new System.Drawing.Size(17, 22);
            this.atlasElementYToolStripLabel.Text = "Y:";
            // 
            // atlasElementYToolStrip
            // 
            this.atlasElementYToolStrip.Name = "atlasElementYToolStrip";
            this.atlasElementYToolStrip.Size = new System.Drawing.Size(13, 22);
            this.atlasElementYToolStrip.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 417);
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
            this.atlasElementsToolStrip.ResumeLayout(false);
            this.atlasElementsToolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStrip atlasElementsToolStrip;
        private System.Windows.Forms.ToolStripLabel atlasElementsToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel atlasElementsCountToolStripLabel;
        private System.Windows.Forms.ToolStripLabel atlasElementsCountIntToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel atlasElementsTitleToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox atlasElementsListToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel atlasElementWidthToolStripLabel;
        private System.Windows.Forms.ToolStripLabel atlasElementWidthToolStrip;
        private System.Windows.Forms.ToolStripLabel atlasElementHeightToolStripLabel;
        private System.Windows.Forms.ToolStripLabel atlasElementHeightToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel atlasElementXToolStripLabel;
        private System.Windows.Forms.ToolStripLabel atlasElementXToolStrip;
        private System.Windows.Forms.ToolStripLabel atlasElementYToolStripLabel;
        private System.Windows.Forms.ToolStripLabel atlasElementYToolStrip;
        private System.Windows.Forms.ToolStripLabel atlasElementBorderColorToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox atlasElementBorderColors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;


    }
}
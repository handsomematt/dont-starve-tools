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

namespace TEXCreator
{
    partial class MainForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mipmapFilterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textureTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generateMipmapsCheckBox = new System.Windows.Forms.CheckBox();
            this.pixelFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputDirectorySearchButton = new System.Windows.Forms.Button();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.selectedTexturesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.preMultiplyAlphaCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logListBox);
            this.panel1.Controls.Add(this.convertButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(8, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 147);
            this.panel1.TabIndex = 0;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(3, 6);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(581, 108);
            this.logListBox.TabIndex = 1;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(509, 121);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 0;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 257);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.preMultiplyAlphaCheckBox);
            this.groupBox2.Controls.Add(this.mipmapFilterComboBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textureTypeComboBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.generateMipmapsCheckBox);
            this.groupBox2.Controls.Add(this.pixelFormatComboBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(312, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 12, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(275, 257);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format:";
            // 
            // mipmapFilterComboBox
            // 
            this.mipmapFilterComboBox.FormattingEnabled = true;
            this.mipmapFilterComboBox.Location = new System.Drawing.Point(11, 121);
            this.mipmapFilterComboBox.Name = "mipmapFilterComboBox";
            this.mipmapFilterComboBox.Size = new System.Drawing.Size(253, 21);
            this.mipmapFilterComboBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mipmap Resize Filter:";
            // 
            // textureTypeComboBox
            // 
            this.textureTypeComboBox.FormattingEnabled = true;
            this.textureTypeComboBox.Location = new System.Drawing.Point(11, 81);
            this.textureTypeComboBox.Name = "textureTypeComboBox";
            this.textureTypeComboBox.Size = new System.Drawing.Size(253, 21);
            this.textureTypeComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Texture Type:";
            // 
            // generateMipmapsCheckBox
            // 
            this.generateMipmapsCheckBox.AutoSize = true;
            this.generateMipmapsCheckBox.Location = new System.Drawing.Point(11, 148);
            this.generateMipmapsCheckBox.Name = "generateMipmapsCheckBox";
            this.generateMipmapsCheckBox.Size = new System.Drawing.Size(115, 17);
            this.generateMipmapsCheckBox.TabIndex = 2;
            this.generateMipmapsCheckBox.Text = "Generate Mipmaps";
            this.generateMipmapsCheckBox.UseVisualStyleBackColor = true;
            // 
            // pixelFormatComboBox
            // 
            this.pixelFormatComboBox.FormattingEnabled = true;
            this.pixelFormatComboBox.Location = new System.Drawing.Point(11, 41);
            this.pixelFormatComboBox.Name = "pixelFormatComboBox";
            this.pixelFormatComboBox.Size = new System.Drawing.Size(253, 21);
            this.pixelFormatComboBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pixel Format:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outputDirectorySearchButton);
            this.groupBox1.Controls.Add(this.outputDirectoryTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.selectedTexturesListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 12, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(306, 257);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input/Output";
            // 
            // outputDirectorySearchButton
            // 
            this.outputDirectorySearchButton.Location = new System.Drawing.Point(271, 230);
            this.outputDirectorySearchButton.Name = "outputDirectorySearchButton";
            this.outputDirectorySearchButton.Size = new System.Drawing.Size(24, 20);
            this.outputDirectorySearchButton.TabIndex = 6;
            this.outputDirectorySearchButton.Text = "...";
            this.outputDirectorySearchButton.UseVisualStyleBackColor = true;
            this.outputDirectorySearchButton.Click += new System.EventHandler(this.outputDirectorySearchButton_Click);
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(11, 231);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(254, 20);
            this.outputDirectoryTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output Directory:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(246, 194);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(49, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // selectedTexturesListBox
            // 
            this.selectedTexturesListBox.FormattingEnabled = true;
            this.selectedTexturesListBox.Location = new System.Drawing.Point(11, 41);
            this.selectedTexturesListBox.Name = "selectedTexturesListBox";
            this.selectedTexturesListBox.ScrollAlwaysVisible = true;
            this.selectedTexturesListBox.Size = new System.Drawing.Size(284, 147);
            this.selectedTexturesListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Textures:";
            // 
            // preMultiplyAlphaCheckBox
            // 
            this.preMultiplyAlphaCheckBox.AutoSize = true;
            this.preMultiplyAlphaCheckBox.Location = new System.Drawing.Point(11, 171);
            this.preMultiplyAlphaCheckBox.Name = "preMultiplyAlphaCheckBox";
            this.preMultiplyAlphaCheckBox.Size = new System.Drawing.Size(109, 17);
            this.preMultiplyAlphaCheckBox.TabIndex = 7;
            this.preMultiplyAlphaCheckBox.Text = "Pre-multiply Alpha";
            this.preMultiplyAlphaCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 420);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm1";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Klei Texture Converter";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox selectedTexturesListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button outputDirectorySearchButton;
        private System.Windows.Forms.TextBox outputDirectoryTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox pixelFormatComboBox;
        private System.Windows.Forms.CheckBox generateMipmapsCheckBox;
        private System.Windows.Forms.ComboBox textureTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox mipmapFilterComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.CheckBox preMultiplyAlphaCheckBox;

    }
}
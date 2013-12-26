namespace TP_CS
{
    partial class MainInterface
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
            this.pictureBoxFractal = new System.Windows.Forms.PictureBox();
            this.btGenerate = new System.Windows.Forms.Button();
            this.scrollContrast = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scrollCR = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.scrollCI = new System.Windows.Forms.HScrollBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboFractType = new System.Windows.Forms.ComboBox();
            this.cb_hq = new System.Windows.Forms.CheckBox();
            this.cbAutoRegenerate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckExpBlue = new System.Windows.Forms.CheckBox();
            this.ckExpGreen = new System.Windows.Forms.CheckBox();
            this.ckExpRed = new System.Windows.Forms.CheckBox();
            this.scrollRed = new System.Windows.Forms.HScrollBar();
            this.label7 = new System.Windows.Forms.Label();
            this.scrollGreen = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.scrollBlue = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.btExport = new System.Windows.Forms.Button();
            this.scrollBrightness = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labBench1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labBenchMark2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labValC = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFractal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxFractal
            // 
            this.pictureBoxFractal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFractal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFractal.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFractal.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxFractal.Name = "pictureBoxFractal";
            this.pictureBoxFractal.Size = new System.Drawing.Size(1023, 733);
            this.pictureBoxFractal.TabIndex = 0;
            this.pictureBoxFractal.TabStop = false;
            this.pictureBoxFractal.SizeChanged += new System.EventHandler(this.onPictureBoxFractalResize);
            this.pictureBoxFractal.Click += new System.EventHandler(this.EventZoomImage);
            this.pictureBoxFractal.Paint += new System.Windows.Forms.PaintEventHandler(this.onPictureBoxFractalRepaint);
            this.pictureBoxFractal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onMouseMove);
            // 
            // btGenerate
            // 
            this.btGenerate.Location = new System.Drawing.Point(17, 23);
            this.btGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(100, 28);
            this.btGenerate.TabIndex = 1;
            this.btGenerate.Text = "Generate";
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.onEventRegenerate);
            // 
            // scrollContrast
            // 
            this.scrollContrast.Location = new System.Drawing.Point(11, 47);
            this.scrollContrast.Name = "scrollContrast";
            this.scrollContrast.Size = new System.Drawing.Size(135, 15);
            this.scrollContrast.TabIndex = 2;
            this.scrollContrast.Value = 80;
            this.scrollContrast.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRedraw);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contrast";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "C.real";
            // 
            // scrollCR
            // 
            this.scrollCR.Location = new System.Drawing.Point(13, 74);
            this.scrollCR.Minimum = -100;
            this.scrollCR.Name = "scrollCR";
            this.scrollCR.Size = new System.Drawing.Size(135, 15);
            this.scrollCR.TabIndex = 4;
            this.scrollCR.Value = 41;
            this.scrollCR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRegenerate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "C.imag";
            // 
            // scrollCI
            // 
            this.scrollCI.Location = new System.Drawing.Point(11, 127);
            this.scrollCI.Minimum = -100;
            this.scrollCI.Name = "scrollCI";
            this.scrollCI.Size = new System.Drawing.Size(135, 15);
            this.scrollCI.TabIndex = 6;
            this.scrollCI.Value = 11;
            this.scrollCI.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRegenerate);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxFractal);
            this.splitContainer1.Size = new System.Drawing.Size(1219, 733);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboFractType);
            this.groupBox2.Controls.Add(this.cb_hq);
            this.groupBox2.Controls.Add(this.cbAutoRegenerate);
            this.groupBox2.Controls.Add(this.scrollCI);
            this.groupBox2.Controls.Add(this.btGenerate);
            this.groupBox2.Controls.Add(this.scrollCR);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(156, 256);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generation";
            // 
            // comboFractType
            // 
            this.comboFractType.FormattingEnabled = true;
            this.comboFractType.Location = new System.Drawing.Point(9, 225);
            this.comboFractType.Margin = new System.Windows.Forms.Padding(4);
            this.comboFractType.Name = "comboFractType";
            this.comboFractType.Size = new System.Drawing.Size(137, 24);
            this.comboFractType.TabIndex = 10;
            this.comboFractType.SelectedIndexChanged += new System.EventHandler(this.onChangeFractalType);
            // 
            // cb_hq
            // 
            this.cb_hq.AutoSize = true;
            this.cb_hq.Location = new System.Drawing.Point(9, 197);
            this.cb_hq.Margin = new System.Windows.Forms.Padding(4);
            this.cb_hq.Name = "cb_hq";
            this.cb_hq.Size = new System.Drawing.Size(104, 21);
            this.cb_hq.TabIndex = 8;
            this.cb_hq.Text = "High quality";
            this.cb_hq.UseVisualStyleBackColor = true;
            // 
            // cbAutoRegenerate
            // 
            this.cbAutoRegenerate.AutoSize = true;
            this.cbAutoRegenerate.Location = new System.Drawing.Point(11, 169);
            this.cbAutoRegenerate.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoRegenerate.Name = "cbAutoRegenerate";
            this.cbAutoRegenerate.Size = new System.Drawing.Size(120, 21);
            this.cbAutoRegenerate.TabIndex = 9;
            this.cbAutoRegenerate.Text = "Auto generate";
            this.cbAutoRegenerate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckExpBlue);
            this.groupBox1.Controls.Add(this.ckExpGreen);
            this.groupBox1.Controls.Add(this.ckExpRed);
            this.groupBox1.Controls.Add(this.scrollRed);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.scrollGreen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.scrollBlue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btExport);
            this.groupBox1.Controls.Add(this.scrollContrast);
            this.groupBox1.Controls.Add(this.scrollBrightness);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 278);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(156, 373);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Post-process";
            // 
            // ckExpBlue
            // 
            this.ckExpBlue.AutoSize = true;
            this.ckExpBlue.Checked = true;
            this.ckExpBlue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExpBlue.Location = new System.Drawing.Point(9, 300);
            this.ckExpBlue.Margin = new System.Windows.Forms.Padding(4);
            this.ckExpBlue.Name = "ckExpBlue";
            this.ckExpBlue.Size = new System.Drawing.Size(101, 21);
            this.ckExpBlue.TabIndex = 21;
            this.ckExpBlue.Text = "Non-Linear";
            this.ckExpBlue.UseVisualStyleBackColor = true;
            this.ckExpBlue.Click += new System.EventHandler(this.onEventRedraw);
            // 
            // ckExpGreen
            // 
            this.ckExpGreen.AutoSize = true;
            this.ckExpGreen.Location = new System.Drawing.Point(11, 234);
            this.ckExpGreen.Margin = new System.Windows.Forms.Padding(4);
            this.ckExpGreen.Name = "ckExpGreen";
            this.ckExpGreen.Size = new System.Drawing.Size(101, 21);
            this.ckExpGreen.TabIndex = 20;
            this.ckExpGreen.Text = "Non-Linear";
            this.ckExpGreen.UseVisualStyleBackColor = true;
            this.ckExpGreen.Click += new System.EventHandler(this.onEventRedraw);
            // 
            // ckExpRed
            // 
            this.ckExpRed.AutoSize = true;
            this.ckExpRed.Location = new System.Drawing.Point(11, 171);
            this.ckExpRed.Margin = new System.Windows.Forms.Padding(4);
            this.ckExpRed.Name = "ckExpRed";
            this.ckExpRed.Size = new System.Drawing.Size(101, 21);
            this.ckExpRed.TabIndex = 19;
            this.ckExpRed.Text = "Non-Linear";
            this.ckExpRed.UseVisualStyleBackColor = true;
            this.ckExpRed.Click += new System.EventHandler(this.onEventRedraw);
            // 
            // scrollRed
            // 
            this.scrollRed.Location = new System.Drawing.Point(11, 149);
            this.scrollRed.Maximum = 200;
            this.scrollRed.Name = "scrollRed";
            this.scrollRed.Size = new System.Drawing.Size(135, 15);
            this.scrollRed.TabIndex = 17;
            this.scrollRed.Value = 25;
            this.scrollRed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRedraw);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Red";
            // 
            // scrollGreen
            // 
            this.scrollGreen.Location = new System.Drawing.Point(11, 212);
            this.scrollGreen.Maximum = 200;
            this.scrollGreen.Name = "scrollGreen";
            this.scrollGreen.Size = new System.Drawing.Size(135, 15);
            this.scrollGreen.TabIndex = 15;
            this.scrollGreen.Value = 70;
            this.scrollGreen.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRedraw);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Green";
            // 
            // scrollBlue
            // 
            this.scrollBlue.Location = new System.Drawing.Point(9, 278);
            this.scrollBlue.Maximum = 200;
            this.scrollBlue.Name = "scrollBlue";
            this.scrollBlue.Size = new System.Drawing.Size(135, 15);
            this.scrollBlue.TabIndex = 13;
            this.scrollBlue.Value = 100;
            this.scrollBlue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRedraw);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Blue";
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(11, 341);
            this.btExport.Margin = new System.Windows.Forms.Padding(4);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(131, 25);
            this.btExport.TabIndex = 12;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.onEventExport);
            // 
            // scrollBrightness
            // 
            this.scrollBrightness.Location = new System.Drawing.Point(11, 92);
            this.scrollBrightness.Maximum = 512;
            this.scrollBrightness.Name = "scrollBrightness";
            this.scrollBrightness.Size = new System.Drawing.Size(135, 15);
            this.scrollBrightness.TabIndex = 10;
            this.scrollBrightness.Value = 255;
            this.scrollBrightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScrollRedraw);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Brightness";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labBench1,
            this.labBenchMark2,
            this.labValC});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1023, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // labBench1
            // 
            this.labBench1.Name = "labBench1";
            this.labBench1.Size = new System.Drawing.Size(0, 17);
            // 
            // labBenchMark2
            // 
            this.labBenchMark2.Name = "labBenchMark2";
            this.labBenchMark2.Size = new System.Drawing.Size(0, 17);
            // 
            // labValC
            // 
            this.labValC.Name = "labValC";
            this.labValC.Size = new System.Drawing.Size(0, 17);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 733);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainInterface";
            this.Text = "Fractal Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFractal)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFractal;
        private System.Windows.Forms.Button btGenerate;
        private System.Windows.Forms.HScrollBar scrollContrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar scrollCR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar scrollCI;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox cbAutoRegenerate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labBench1;
        private System.Windows.Forms.ToolStripStatusLabel labBenchMark2;
        private System.Windows.Forms.HScrollBar scrollBrightness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel labValC;
        private System.Windows.Forms.CheckBox cb_hq;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.HScrollBar scrollRed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar scrollGreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar scrollBlue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckExpBlue;
        private System.Windows.Forms.CheckBox ckExpGreen;
        private System.Windows.Forms.CheckBox ckExpRed;
        private System.Windows.Forms.ComboBox comboFractType;
    }
}
namespace TP_CS
{
    partial class ExportImage
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtViewWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtViewPosX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtViewHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtViewPosY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width :";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(61, 13);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(86, 20);
            this.tbWidth.TabIndex = 1;
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(61, 39);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(86, 20);
            this.tbHeight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height :";
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(12, 251);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(73, 23);
            this.btExport.TabIndex = 4;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "px";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "px";
            // 
            // txtViewWidth
            // 
            this.txtViewWidth.Location = new System.Drawing.Point(73, 75);
            this.txtViewWidth.Name = "txtViewWidth";
            this.txtViewWidth.Size = new System.Drawing.Size(86, 20);
            this.txtViewWidth.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Width :";
            // 
            // txtViewPosX
            // 
            this.txtViewPosX.Location = new System.Drawing.Point(73, 19);
            this.txtViewPosX.Name = "txtViewPosX";
            this.txtViewPosX.Size = new System.Drawing.Size(86, 20);
            this.txtViewPosX.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Position X :";
            // 
            // txtViewHeight
            // 
            this.txtViewHeight.Location = new System.Drawing.Point(73, 101);
            this.txtViewHeight.Name = "txtViewHeight";
            this.txtViewHeight.Size = new System.Drawing.Size(86, 20);
            this.txtViewHeight.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Height :";
            // 
            // txtViewPosY
            // 
            this.txtViewPosY.Location = new System.Drawing.Point(73, 45);
            this.txtViewPosY.Name = "txtViewPosY";
            this.txtViewPosY.Size = new System.Drawing.Size(86, 20);
            this.txtViewPosY.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Position Y :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtViewPosX);
            this.groupBox1.Controls.Add(this.txtViewHeight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtViewPosY);
            this.groupBox1.Controls.Add(this.txtViewWidth);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 167);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ViewPort";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 21);
            this.button1.TabIndex = 16;
            this.button1.Text = "Force 1:1 AR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickAspectRatio);
            // 
            // ExportImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 282);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.label1);
            this.Name = "ExportImage";
            this.Text = "Fractal Export";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtViewWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtViewPosX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtViewHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtViewPosY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}
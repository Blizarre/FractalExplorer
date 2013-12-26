using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_CS
{
    public partial class ExportImage : Form
    {
        FractalParameters _fractalP;
        RenderingParameters _renderP;

        public ExportImage(FractalParameters fp, RenderingParameters rp)
        {
            _fractalP = fp;
            _renderP = rp;

            InitializeComponent();

            txtViewPosX.Text = _fractalP.viewPort.X.ToString();
            txtViewPosY.Text = _fractalP.viewPort.Y.ToString();
            txtViewWidth.Text = _fractalP.viewPort.Width.ToString();
            txtViewHeight.Text = _fractalP.viewPort.Height.ToString();
        }

        public class AspectRatio {
            public String Label { get; set; }
            public double Aspect { get; set; }
            public AspectRatio(String label, double aspect) { Label = label; Aspect = aspect; }
            public override String ToString() { return Label; }
        };

        private void btExport_Click(object sender, EventArgs e)
        {
            int width, height;
            SaveFileDialog sfd;
            Bitmap im;
            FractalGenerator fractalG;
            String fileName;

            try
            {
                width = int.Parse(tbWidth.Text);
                height = int.Parse(tbHeight.Text);
                sfd = new SaveFileDialog();
                sfd.DefaultExt = ".png";
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image png (*.png)|*.png|Image jpeg (*.jpg)|*.jpg";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    fileName = sfd.FileName;
                    // Forced AA * 4 (size *2 on with, Height)
                    _fractalP.width = width * 2;
                    _fractalP.height = height * 2;

                    _fractalP.viewPort.X = float.Parse(txtViewPosX.Text);
                    _fractalP.viewPort.Y = float.Parse(txtViewPosY.Text);
                    _fractalP.viewPort.Width = float.Parse(txtViewWidth.Text);
                    _fractalP.viewPort.Height = float.Parse(txtViewHeight.Text);

                    _fractalP.highQuality = true;

                    this.Enabled = false;
                    this.tbHeight.Enabled = false;
                    this.tbWidth.Enabled = false;
                    fractalG = new FractalGenerator(width, height);
                    fractalG.generate(_fractalP, null);
                    fractalG.generateImage(_renderP, null);
                    im = fractalG.Image;
                    this.Enabled = true;
                    // 2x High quality downscaling

                    Bitmap tmpImage = new Bitmap(width, height, im.PixelFormat);
                    Graphics handle = Graphics.FromImage(tmpImage);
                    handle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    handle.DrawImage(fractalG.Image, 0, 0, width, height);
                    // Save the image
                    tmpImage.Save(fileName);

                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Numerical Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show("Invalid Image name : " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Add others
                    




        }

        /**
         * Change the aspect ratio of the viewport : the image will have a 
         */
        private void ClickAspectRatio(object sender, EventArgs e)
        {
            try
            {
                double aspectRatio;
                double oldViewPortWidth, newViewPortWidth, diffViewPortWidth;
                double newViewPortPosX;

                aspectRatio = double.Parse(tbWidth.Text) / double.Parse(tbHeight.Text);

                oldViewPortWidth = double.Parse(txtViewHeight.Text);
                newViewPortWidth = oldViewPortWidth * aspectRatio;
                
                diffViewPortWidth = newViewPortWidth -  oldViewPortWidth;
                newViewPortPosX = double.Parse(txtViewPosX.Text) - diffViewPortWidth / 2.0;

                txtViewPosX.Text = newViewPortPosX.ToString();
                txtViewWidth.Text = newViewPortWidth.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Numerical Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }

}

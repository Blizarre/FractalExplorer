using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP_CS
{
    public partial class ExportImage : Form
    {
        FractalGenerator _fractalG;
        FractalParameters _fractalP;
        RenderingParameters _renderP;

        public ExportImage(FractalGenerator fg, FractalParameters fp, RenderingParameters rp)
        {
            _fractalG = fg;
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
                    String name = sfd.FileName;

                    _fractalP.width = width;
                    _fractalP.height = height;

                    _fractalP.viewPort.X = float.Parse(txtViewPosX.Text);
                    _fractalP.viewPort.Y = float.Parse(txtViewPosY.Text);
                    _fractalP.viewPort.Width = float.Parse(txtViewWidth.Text);
                    _fractalP.viewPort.Height = float.Parse(txtViewHeight.Text);

                    _fractalP.highQuality = true;

                    this.Enabled = false;
                    this.tbHeight.Enabled = false;
                    this.tbWidth.Enabled = false;
                    _fractalG.generate(_fractalP, null);
                    im = _fractalG.getImage(_renderP);
                    this.Enabled = true;
                    im.Save(name);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.Threading.Tasks;
using System.Threading;

namespace TP_CS
{

    public partial class MainInterface : Form
    {
        FractalGenerator _fractalG = null;
        RectangleF _viewPort;

        DateTime _d1;
        Task t;

        // This object is shared with the data generation thread and will be able 
        // to abort the generation if needed
        CancellationTokenSource cts;

        // This ParallelOptions object embed the CancellationTokens and is shared with the Tasks 
        ParallelOptions po;

        /**
         * Called when the generation of the image is finished, and it is ready to be drawed on-screen.
         * This call-back function will update the status bar with the generation time
         * and draw the generated image.
         * */
        private void generationOk(object sender, EventArgs eg)
        {
            drawImage();
            DateTime d2 = DateTime.Now;
            labBench1.Text = String.Format("generation time : {0:0} ms", d2.Subtract(_d1).TotalMilliseconds);
            drawImage();
        }



        public MainInterface()
        {
            InitializeComponent();
            _fractalG = new FractalGenerator();
            _fractalG.generationDone += generationOk;
            _viewPort = new RectangleF(-1, -1, 2, 2);

            regenerate();
            
        }

        





        private void regenerate()
        {
            FractalParameters fp = getFractalParam();

            // Used for benchmarking
            _d1 = DateTime.Now;

            if (t != null && !t.IsCompleted)
            {
                cts.Cancel(); // Cancel previous threads
                t.Wait(); // Wait until they really end
                t.Dispose();
            }

            // Recreate new tokens for the next Task 
            cts = new CancellationTokenSource();
            po = new ParallelOptions();
            po.CancellationToken = cts.Token;

            t = Task.Factory.StartNew(() =>
                {
                    _fractalG.generate(fp, po);
                });
        }





        /**
         * Draw the generated data (from regenerate()) on the pictureBox. Basic benchmarking is performed
         */
        private void drawImage()
        {
            DateTime d1 = DateTime.Now;
            try
            {
                pictureBox1.Image = _fractalG.getImage(getRenderingParam());
            }
            catch (ImageNotReadyException)
            {
                MessageBox.Show("Image not ready yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime d2 = DateTime.Now;
            labBenchMark2.Text = String.Format("Drawing time : {0:0} ms", d2.Subtract(d1).TotalMilliseconds);
        }


        /* Move the fractal view to center it on the (clickX, clickY) point */
        public void moveView(int clickX, int clickY)
        {
            int decalageCentragePixX = (-pictureBox1.Size.Width / 2 + clickX);
            int decalageCentragePixY = (-pictureBox1.Size.Height / 2 + clickY);

            float decalageX = decalageCentragePixX * (_viewPort.Width / (float)pictureBox1.Size.Width);
            float decalageY = decalageCentragePixY * (_viewPort.Height / (float)pictureBox1.Size.Height);

            _viewPort.Move(decalageX, decalageY);
        }

        /* Called if the picture si clicked on : used to move in the image */
        private void zoomImage(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            switch (mea.Button) {

                case MouseButtons.Left:
                    moveView(mea.X, mea.Y);
                    _viewPort.Shrink(0.5f);
                    break;

                case MouseButtons.Right:
                    _viewPort.Shrink(2f);
                    break;

                case MouseButtons.Middle:
                    moveView(mea.X, mea.Y);
                    break;
            }
            regenerate();
        }



        /**
         * Prepare the drawing Parameters from the drawImage step
         **/
        private RenderingParameters getRenderingParam()
        {
            RenderingParameters rp;
            rp.brightness = (float)scrollBrightness.Value - 255.0f;
            rp.contrast = (float)scrollContrast.Value;

            rp.GreenExp = ckExpGreen.Checked;
            rp.RedExp   = ckExpRed.Checked;
            rp.BlueExp  = ckExpBlue.Checked;
            
            rp.RedParam   = (float)(scrollRed.Value / 100.0);
            rp.BlueParam  = (float)(scrollBlue.Value / 100.0);
            rp.GreenParam = (float)(scrollGreen.Value / 100.0);
            
            return rp;
        }


        /**
         * Prepare the Fractal data generation parameters from the values
         * of the UI
         * */
        private FractalParameters getFractalParam()
        {
            FractalParameters fp;
            fp.width = pictureBox1.Size.Width;
            fp.height = pictureBox1.Size.Height;
            fp.highQuality = cb_hq.Checked;

            // Keep aspect ratio of the at 1:1
            _viewPort.Width = ((float)pictureBox1.Size.Width / pictureBox1.Size.Height) * _viewPort.Height;
            
            fp.viewPort = _viewPort.clone();

            // c between (0,0) and (1,1)
            fp.c = new Complex((float)scrollCR.Value / 100.0f, (float)scrollCI.Value / 100.0f);
            return fp;
        }


        /** Callback for the Export Image Form */
        private void btExport_Click(object sender, EventArgs e)
        {
            ExportImage eim = new ExportImage(_fractalG, getFractalParam(), getRenderingParam());
            eim.ShowDialog();
            regenerate();
        }

        /** All the force redraw/regenerate Events */

        private void EventRedraw(object sender, EventArgs e)
        {
            drawImage();
        }
        
        private void scroll_redraw(object sender, ScrollEventArgs e)
        {
            drawImage();
        }

        private void scroll_regenerate(object sender, ScrollEventArgs e)
        {
            if (cbAutoRegenerate.Checked)
                regenerate();
        }

        private void EventRegenerate(object sender, EventArgs e)
        {
            regenerate();
        }

        private void pictureBoxResize(object sender, EventArgs e)
        {
            if (cbAutoRegenerate.Checked)
                regenerate();
        }
    }
}

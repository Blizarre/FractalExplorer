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

        DateTime _dateStartGeneration;
        DateTime _dateStartDrawing;


        Task t;

        // This object is shared with the data generation thread and will be able 
        // to abort the generation if needed
        CancellationTokenSource cts;

        // This ParallelOptions object embed the CancellationTokens and is shared with the Tasks 
        ParallelOptions po;

        private delegate void GenerationImageOkHandler();
        private delegate void GenerationDataOkHandler(Boolean b);
        //private delegate void GenerationDataOkHandler();

        public delegate void generationDataDoneDelegate(Boolean newData);
        public event generationDataDoneDelegate DataGenerationDone;


        private Graphics pictureBoxGraphics;

        Mutex accessImage = new Mutex();
        Mutex accessThread = new Mutex();
        Mutex generating = new Mutex();

        /**
         * Called when the image generation is finished.
         * */
        private void ImageGeneratedOk()
        {
            DateTime d2 = DateTime.Now;
            labBenchMark2.Text = String.Format("drawing time : {0:0} ms", d2.Subtract(_dateStartDrawing).TotalMilliseconds);

            accessImage.WaitOne();
            pictureBoxGraphics.DrawImage(_fractalG.Image, new Point(0, 0));
            accessImage.ReleaseMutex();
        }


        /**
         * Called when the generation of the fractal data is finished, and it is ready to be drawed on-screen.
         * This call-back function will update the status bar with the generation time
         * and draw the generated image.
         * */
        protected void DataGeneratedOk(Boolean newImage)
        {
            DateTime d2 = DateTime.Now;
            labBench1.Text = String.Format("generation time : {0:0} ms", d2.Subtract(_dateStartGeneration).TotalMilliseconds);
            // The image has been changed
            if (newImage)
            {
                accessImage.WaitOne();
                pictureBoxGraphics = pictureBoxFractal.CreateGraphics();
                accessImage.ReleaseMutex();
            }
            drawImage();
        }

        public MainInterface()
        {
            InitializeComponent();
            _fractalG = new FractalGenerator(pictureBoxFractal.Size);
            pictureBoxGraphics = pictureBoxFractal.CreateGraphics();
            comboFractType.Items.Add(FractalType.JULIA);
            comboFractType.Items.Add(FractalType.MANDELBROT);
            comboFractType.SelectedItem = FractalType.JULIA;
            DataGenerationDone += DataGeneratedOk;
            _viewPort = new RectangleF(-1, -1, 2, 2);
            regenerate();
        }


        private void regenerate()
        {
            FractalParameters fp = getFractalParam();
            labValC.Text = String.Format("c = {0} + {1}i", fp.c._real, fp.c._imag);

            // Used for benchmarking
            _dateStartGeneration = DateTime.Now;

            accessThread.WaitOne();

            if (t != null && !t.IsCompleted)
            {
                cts.Cancel(false); // Cancel previous thread
                t.Wait(); // Wait until they really end
            }

            // Recreate new tokens for the next Task 
            cts = new CancellationTokenSource();

            t = Task.Factory.StartNew(() =>
            {
                Boolean imageChanged;
                try
                {
                    imageChanged = _fractalG.generate(fp, cts.Token);
                }
                catch (OperationCanceledException) { return; }
                DataGenerationDone(imageChanged);
            });
            accessThread.ReleaseMutex();
        }


        /**
         * Draw the generated data (from regenerate()) on the pictureBox. Basic benchmarking is performed.
         */
        private void drawImage()
        {
            // Used for benchmarking
            _dateStartDrawing = DateTime.Now;
            accessImage.WaitOne();
            _fractalG.generateImage(getRenderingParam(), null);
            accessImage.ReleaseMutex();
            ImageGeneratedOk();
        }


        /* Move the fractal view to center it on the (clickX, clickY) point */
        public void moveView(int clickX, int clickY)
        {
            int decalageCentragePixX = (-pictureBoxFractal.Size.Width / 2 + clickX);
            int decalageCentragePixY = (-pictureBoxFractal.Size.Height / 2 + clickY);

            float decalageX = decalageCentragePixX * (_viewPort.Width / (float)pictureBoxFractal.Size.Width);
            float decalageY = decalageCentragePixY * (_viewPort.Height / (float)pictureBoxFractal.Size.Height);

            _viewPort.Move(decalageX, decalageY);
        }

        /* Called if the picture si clicked on : used to move in the image */
        private void EventZoomImage(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            switch (mea.Button)
            {

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
            rp.RedExp = ckExpRed.Checked;
            rp.BlueExp = ckExpBlue.Checked;

            rp.RedParam = (float)(scrollRed.Value / 100.0);
            rp.BlueParam = (float)(scrollBlue.Value / 100.0);
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
            fp.width = pictureBoxFractal.Size.Width;
            fp.height = pictureBoxFractal.Size.Height;
            fp.highQuality = cb_hq.Checked;

            // Keep the aspect ratio at 1:1
            _viewPort.Width = ((float)pictureBoxFractal.Size.Width / pictureBoxFractal.Size.Height) * _viewPort.Height;

            // Any modification of the export struct must not affect current viewport
            fp.viewPort = _viewPort.clone();

            fp.type = (FractalType)comboFractType.SelectedItem;

            // c between (-1,-1) and (1,1)
            fp.c = new Complex((float)scrollCR.Value / 100.0f, (float)scrollCI.Value / 100.0f);
            return fp;
        }


        /** Callback for the Export Image Form */
        private void onEventExport(object sender, EventArgs e)
        {
            ExportImage eim = new ExportImage(getFractalParam(), getRenderingParam());
            eim.ShowDialog();
            regenerate();
        }

        /** All the force redraw/regenerate Events */

        private void onEventRedraw(object sender, EventArgs e)
        {
            drawImage();
        }

        private void onScrollRedraw(object sender, ScrollEventArgs e)
        {
            drawImage();
        }

        private void onScrollRegenerate(object sender, ScrollEventArgs e)
        {
            if (cbAutoRegenerate.Checked)
                regenerate();
        }

        private void onEventRegenerate(object sender, EventArgs e)
        {
            regenerate();
        }

        private void onPictureBoxFractalResize(object sender, EventArgs e)
        {
            if (cbAutoRegenerate.Checked)
                regenerate();
        }

        private void onPictureBoxFractalRepaint(object sender, PaintEventArgs e)
        {
            drawImage();
        }

        private void onChangeFractalType(object sender, EventArgs e)
        {
            if ((FractalType)comboFractType.SelectedItem != FractalType.JULIA)
            {
                scrollCI.Enabled = false;
                scrollCR.Enabled = false;
            }
            else
            {
                scrollCI.Enabled = true;
                scrollCR.Enabled = true;
            }
            if (cbAutoRegenerate.Checked)
                regenerate();
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            labBenchMark2.Text = String.Format("({0:D}, {1:D}) = {2:F1}",  e.X , e.Y, _fractalG.getNbIterations(e.X, e.Y));
        }
    }
}
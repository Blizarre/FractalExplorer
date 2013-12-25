using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;


namespace TP_CS
{

    public class ImageNotReadyException : Exception { }

    public class FractalGenerator
    {
        private float[] _tabResultComputation;
        byte[] _tabResultImage;
        Bitmap _resultImage;

        protected int _width; // Width of the image
        protected int _height; // Height of the image

        public Bitmap Image { get { return _resultImage; } }

        public FractalGenerator(int width, int height)
        {
            init(width, height);
        }

        public void init(int width, int height)
        {
            _tabResultComputation = new float[height * width];
            _tabResultImage = new byte[4 * height * width];
            _resultImage = new Bitmap(width, height, PixelFormat.Format32bppRgb);
            _width = width;
            _height = height;
        }

        public FractalGenerator(Size s) : this(s.Width, s.Height) { }

        public void generateImage(RenderingParameters rp, ParallelOptions po)
        {

            int pixelSize = 4;
            BitmapData bd;

            if (po == null) 
                po = new ParallelOptions();
            else 
                po.CancellationToken.ThrowIfCancellationRequested();

            // The image exist and has been created in the generate() function
            bd = _resultImage.LockBits(new Rectangle(0, 0, _width, _height), System.Drawing.Imaging.ImageLockMode.WriteOnly, _resultImage.PixelFormat);

            try
            {

                Parallel.For(0, _height, po, j =>
                {
                    byte valR, valG, valB;
                    float val;
                    int posPixel = bd.Stride * j;
                    for (int i = 0; i < _width; i++)
                    {
                        /**
                         * Convert the iteration number in a byte => iteration space to image space
                         * result = log(iter) * contrast + brightness
                         * log(iter) has already been performed in the generation
                         * Do not perform boundary checking
                         **/
                        val = getValAt(i, j) * rp.contrast + rp.brightness;
                        valR = castFloatToByte(val * rp.RedParam, rp.RedExp);
                        valG = castFloatToByte(val * rp.GreenParam, rp.GreenExp);
                        valB = castFloatToByte(val * rp.BlueParam, rp.BlueExp);
                        _tabResultImage[posPixel + 0] = valB;
                        _tabResultImage[posPixel + 1] = valG;
                        _tabResultImage[posPixel + 2] = valR;
                        posPixel += pixelSize;
                    }
                });

                Marshal.Copy(_tabResultImage, 0, bd.Scan0, _height * bd.Stride);
            }
            catch (OperationCanceledException e) { throw e; }
            finally
            {
                _resultImage.UnlockBits(bd);
            }
        }



        /**
         * Julia value computation
         * param name="c" Julia initialization parameter
         * param name="z" Pixel position in the complex plane()
         * param name="N" Bailout value : minimum 2, higher number give better smoothing
         * param name="smoothing" Smooth the resulting image
         * */
        private float ComputeValAt(Complex z, Complex c, bool smoothing, int N, int maxIter)
        {
            int iter = 0;
            double value;
            float newImag; // temporary value for the real part of z

            // If a one point |z_n| > N, the function is considered divergent. N=2 is enough as a mathematical proof
            // However higher number are used to get a better resolution in the smothing function
            for (iter = 0; iter < maxIter && z.AbsSq() < N * N; iter++)
            {
                // z^{n+1} = z^n * z^n + c
                // also : z.SquareAddIP(c);
                // almost x2 speedup by inlining code, no property used
                newImag = 2 * z._real * z._imag + c._imag;
                z._real = z._real * z._real - z._imag * z._imag + c._real;
                z._imag = newImag;
            }

            value = (double)iter;

            //Smoothing :
            // realResult = n - log_p(log(|z_n|/log(N))
            // p = 2 (exponent of z in the julia formulae)
            // n = iteration number achieved during bailout detection
            // N = bailout, bigger number, better results.
            if (smoothing)
                value -= Math.Log(Math.Log(Math.Sqrt(z.AbsSq()) / Math.Log(N), 2));

            // Do it right away, will speed up the drawing image process
            return (float)Math.Log(value);
        }

        /**
         * Generate the data. return true if the Image property has been changed.
         **/
        public bool generate(FractalParameters fp, CancellationToken? ct)
        {
            bool innerDataChanged = false;

            // default value
            ParallelOptions po = new ParallelOptions();
            if (ct != null) 
                po.CancellationToken = (CancellationToken)ct;    

            // If the size of the generation has changed or if it is the first generation
            if (_tabResultComputation == null || fp.width != _width || fp.height != _height)
            {
                init(fp.width, fp.height);
                innerDataChanged = true;
            }

            float mulX = fp.viewPort.Width / (float)fp.width;
            float mulY = fp.viewPort.Height / (float)fp.height;
            float baseX = (float)fp.viewPort.X;
            float baseY = (float)fp.viewPort.Y;
            int bailout;
            int maxIter;

            if (fp.highQuality)
            {
                bailout = 1000;
                maxIter = 3000;
            }
            else
            {
                bailout = 2;
                maxIter = 255;
            }

            po.CancellationToken.ThrowIfCancellationRequested();

            try
            {
                Parallel.For(0, _height, po, j =>
                {
                    Complex z;
                    Complex c;
                    switch (fp.type)
                    {
                        case FractalType.MANDELBROT:
                            c._imag = j * mulY + baseY;;
                            for (int i = 0; i < _width; i++)
                            {
                                z = new Complex(0, 0);
                                c._real = i * mulX + baseX;
                                setValAt(i, j, ComputeValAt(z, c, fp.highQuality, bailout, maxIter));
                            }
                            break;
                        case FractalType.JULIA:
                            c = fp.c;
                            for (int i = 0; i < _width; i++) {
                                z._imag = j * mulY + baseY;
                                z._real = i * mulX + baseX;
                                setValAt(i, j, ComputeValAt(z, c, fp.highQuality, bailout, maxIter));
                            }
                            break;
                        default:
                            throw new System.NotImplementedException(fp.type + "is not implemented");
                    }
                    

                });
            }
            catch (OperationCanceledException e) { throw e; }

            return innerDataChanged;
        }


        /**
         * Small method to convert a float to a Byte, perform boundary checking.
         * Has a good chance to be inlined since it is very small
         **/
        private byte castFloatToByte(float val, bool exp)
        {
            byte ret;

            if (exp) val = val * (float)Math.Sqrt(val);

            if (val > byte.MaxValue)
                ret = byte.MaxValue;
            else if (val < 0)
                ret = 0;
            else
                ret = (byte)val;
            return ret;
        }



        protected float getValAt(int x, int y)
        {
            return _tabResultComputation[x + y * _width];
        }

        protected void setValAt(int x, int y, float val)
        {
            _tabResultComputation[x + y * _width] = val;
        }
    }

    public enum FractalType { JULIA, MANDELBROT };

    public struct FractalParameters
    {
        public FractalType type;
        public Complex c; // Initialization of the julia function
        public RectangleF viewPort; // view of the fractal
        public int width; // width in pixel
        public int height; // width in pixel
        public bool highQuality; // enable smoothing
    }

    public struct RenderingParameters
    {
        public float contrast;
        public float brightness;
        public float RedParam;
        public float GreenParam;
        public float BlueParam;
        public bool RedExp;
        public bool GreenExp;
        public bool BlueExp;
    }
}

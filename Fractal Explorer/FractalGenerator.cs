using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace TP_CS
{

    public class ImageNotReadyException:Exception { }

    public class FractalGenerator
    {
        private float[] _tabResultComputation;
        byte[] _tabResultImage;

        int _width; // Width of the image
        int _height; // Height of the image

        public event EventHandler generationDone;

        bool _invalidate; // Parameters of the image have changed : regenerate image

        public FractalGenerator(int height, int width)
        {
            this._tabResultComputation = new float[height * width];
            this._tabResultImage = new byte[height * width];

            this._width = width;
            this._height = height;
            this._invalidate = true;
        }

        public FractalGenerator(Size s) : this(s.Height, s.Width) { }

        public FractalGenerator() : this(0, 0) { }

        public Bitmap getImage(RenderingParameters rp)
        {
            if (_invalidate) throw new ImageNotReadyException();

            Bitmap im = new Bitmap(_width, _height, PixelFormat.Format32bppRgb);

            Rectangle rect = new Rectangle(0, 0, _width, _height);
            BitmapData bd = im.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, im.PixelFormat);


            // Re-use previous Byte array
            int sizeOfTempTab = bd.Height * bd.Stride;
            if ( (_tabResultImage == null) || _tabResultImage.Count() != sizeOfTempTab )
            {
                _tabResultImage = new byte[sizeOfTempTab];
            }

            int pixelSize = 4;
   
            DateTime d1 = DateTime.Now;

            Parallel.For(0, _height, j => 
            {
                byte valR, valG, valB;
                float val;
                int posPixel = bd.Stride * j;
                for (int i = 0; i < _width; i++)
                {
                    val = (float)Math.Log(getValAt(i, j)) * rp.contrast + rp.brightness;
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


            im.UnlockBits(bd);
            return im;
        }

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
        
        /**
         * Convert the iteration number in a byte => iteration space to image space
         * result = log(iter) * contrast + brightness
         * Do not perform boundary checking
         **/
        private float convertValToImage(float iter, float contrast, int brightness)
        {
            return (float)Math.Log(iter) * contrast + brightness;
        }

        protected float getValAt(int x, int y)
        {
            return _tabResultComputation[x + y * _width];
        }

        protected void setValAt(int x, int y, float val)
        {
            _tabResultComputation[x + y * _width] = val;
        }

        /**
         * Julia value computation
         * param name="c" Julia initialization parameter
         * param name="z" Pixel position in the complex plane() . Is modified.
         * param name="N" Bailout value : minimum 2, higher number give better smoothing
         * param name="smoothing" Smooth the resulting image
         * */
        private float ComputeValAt(Complex z, Complex c, bool smoothing, int N, int maxIter)
        {
            int iter = 0;
            float value;
            float newReal; // temporary value for the real part of z
            
            // If a one point |z_n| > N, the function is considered divergent. N=2 is enough as a mathematical proof
            // However higher number are used to get a better resolution in the smothing function
            for (iter = 0; iter < maxIter && z.AbsSq() < N*N; iter++)
            {
                // z^{n+1} = z^n * z^n + c
                // also : z.SquareAddIP(c);
                // almost x2 speedup by inlining code, no property used (speedup?)
                newReal = 2 * z._real * z._imag + c._real;
                z._imag = z._real * z._real - z._imag * z._imag + c._imag;
                z._real = newReal;
            }

            value = (float)iter;
            
            //Smoothing :
            // realResult = n - log_p(log(|z_n|/log(N))
            // p = 2 (exponent of z in the julia formulae)
            // n = iteration number achieved during bailout detection
            // N = bailout, bigger number, better results.
            if(smoothing)
                value -= (float)Math.Log( Math.Log(Math.Sqrt( z.AbsSq() )/Math.Log(N), 2) );

            return value;
        }

        public void generate(FractalParameters fp, ParallelOptions po)
        {
            // default value
            if (po == null) po = new ParallelOptions();

            _tabResultComputation = new float[fp.height * fp.width];
            _width = fp.width;
            _height = fp.height;

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

            try
            {
                Parallel.For(0, _height, po, j =>
                {
                    Complex z = new Complex();
                    for (int i = 0; i < _width; i++)
                    {
                        z._real = i * mulX + baseX;
                        z._imag = j * mulY + baseY;
                        setValAt(i, j, ComputeValAt(z, fp.c, fp.highQuality, bailout, maxIter));
                    }
                });
            }
            catch (OperationCanceledException) {
                return;
            }

            _invalidate = false;
            if (generationDone != null)
                generationDone(this, EventArgs.Empty);

        }

    }

    public struct FractalParameters
    {
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

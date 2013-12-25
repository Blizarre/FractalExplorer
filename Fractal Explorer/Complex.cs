using System;

namespace TP_CS
{

    public struct Complex
    {
        public float _real;
        public float _imag;

        public Complex(float real, float imag)
        {
            this._real = real;
            this._imag = imag;
        }

        public Complex(int real, int imag)
        {
            this._real = (float)real;
            this._imag = (float)imag;
        }

        public void SquareAddIP(Complex c2)
        {
            // TODO: See SquareIP + inlining (faster)
            float imag = this._real * this._real - this._imag * this._imag;
            float real = 2 * this._real * this._imag;
            this._imag = imag + c2._imag;
            this._real = real + c2._real;
        }

        public void SquareIP()
        {
            
              //  (a + ib) * (a + ib) = a² + iab + iab + (ib)²
              //  (a + ib) * (a + ib) = a² + iab + iab + i²b²
              //  (a + ib) * (a + ib) = a² + iab + iab + -b²
              //  (a + ib) * (a + ib) = a² -b² + i2ab
                
            float imag = this._real * this._real - this._imag * this._imag;
            float real = 2 * this._real * this._imag;
            this._imag = imag;
            this._real = real;
        }

        public float AbsSq()
        {
            return this._real * this._real + this._imag * this._imag;
        }

        public void AddIP(Complex c2)
        {
            this._real += c2._real;
            this._imag += c2._imag;
        }

        public Complex Add(Complex c2)
        {
            return new Complex(this._real + c2._real, this._imag + c2._imag);
        }


        public Complex MyClone()
        {
            return new Complex(this._real, this._imag);
        }

    }
}

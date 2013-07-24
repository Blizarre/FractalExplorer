using System;

namespace TP_CS
{


    public class RectangleF
    {

        float _x;
        float _y;
        float _width;
        float _height;

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }


        public RectangleF(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;

            _width = width;
            _height = height;
        }

        public RectangleF() {       }

        public void Move(float dX, float dY)
        {
            _x += dX;
            _y += dY;
        }

        public void Shrink(float val)
        {
            _x += (_width - (val * _width)) / 2;
            _y += (_height- (val * _height)) / 2;

            _width *= val;
            _height *= val;
        }

        public RectangleF clone()
        {
            RectangleF r = new RectangleF();
            r._height = _height;
            r._width = _width;
            r._x = _x;
            r._y = _y;
            return r;
        }
    }

}
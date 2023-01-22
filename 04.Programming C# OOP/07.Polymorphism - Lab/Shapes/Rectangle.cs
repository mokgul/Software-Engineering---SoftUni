
using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double _height;
        private double _width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height
        {
            get => _height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _height = value;
            }
        }

        public double Width
        {
            get => _width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _width = value;
            }
        }

        public override double CalculatePerimeter()
            => 2 * Height + 2 * Width;

        public override double CalculateArea()
            => Height * Width;

        public override string Draw()
        => $"Drawing {nameof(Rectangle)}";
    }
}

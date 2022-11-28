
namespace Shapes
{
    using System;
    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => _radius;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _radius = value;
            }
        }

        public override double CalculatePerimeter()
        => 2 * Math.PI * Radius;

        public override double CalculateArea()
            => Math.PI * Radius * Radius;

        public override string Draw()
            => $"Drawing {nameof(Circle)}";
    }
}

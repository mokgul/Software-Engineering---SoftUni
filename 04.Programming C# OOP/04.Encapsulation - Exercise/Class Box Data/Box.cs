using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                length = value;
            }
        }
        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                width = value;
            }
        }
        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                height = value;
            }
        }

        public double LateralSurfaceArea()
            => (2 * Length * Height + 2 * Width * Height);

        public double SurfaceArea()
            => LateralSurfaceArea() + (2 * Length * Width);

        public double Volume()
            => Length * Width * Height;

        public override string ToString()
            => new StringBuilder()
                .AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}").ToString().TrimEnd();
    }
}

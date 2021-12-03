using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{

    public class Rectangle : Figure
    {
        private double length;
        private double width;

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Length", "must be more than 0.");
                }
                else { length = value; }
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Width", "must be more than 0.");
                }
                else { width = value; }
            }
        }

        public override double GetArea()
        {
            return Length * Width;
        }

        public override double GetPerimeter()
        {
            return 2 * (Length + Width);
        }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
    }
}

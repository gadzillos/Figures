using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    public class Circle : Figure
    {
        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Radius", "must be more than 0.");
                }
                else { radius = value; }
            }
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
}

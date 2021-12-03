using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    public class Triangle : Figure
    {
        private double sideAB;
        private double sideBC;
        private double sideAC;
        private double angleA;
        private double angleB;
        private double angleC;

        public Triangle(double sideAB, double sideBC, double sideAC)
        {
            SideAB = sideAB;
            SideBC = sideBC;
            SideAC = sideAC;

            //checks if triangle exist
            if (!((sideAB + sideBC > sideAC) & (sideAB + sideAC > sideBC) & (sideBC + sideAC > sideAB)))
            {
                Console.WriteLine($"Triangle with sides {sideAB}, {sideBC}, {sideAC} does not exist\n");
                throw new Exception("Wrong triangle sides");
            }

            AngleA = Math.Acos(((SideAB * SideAB) + (SideAC * SideAC) - (SideBC *SideBC)) / (2 * SideAB * SideAC));
            AngleB = Math.Acos(((SideAB * SideAB) + (SideBC * SideBC) - (SideAC * SideAC)) / (2 * SideAB * SideBC));
            AngleC = Math.Acos(((SideBC * SideBC) + (SideAC * SideAC) - (SideAB * SideAB)) / (2 * SideBC * SideAC));
        }

        public Triangle(double sideAB, double sideBC, double angleB, string angleType)
        {
            SideAB = sideAB;
            SideBC = sideBC;
            //converts angle value to radians, throws exceptions if angleType has a typo
            if (angleType.ToLower().Trim() == "deg")
            {
                angleB = (Math.PI / 180) * angleB;
            }
            else if (angleType.ToLower().Trim() != "rad")
            {
                Console.WriteLine("type 'deg' or 'rad' for angle");
                throw new Exception("Wrong angle type argument");
            }
            AngleB = angleB;
            SideAC = Math.Sqrt((sideAB * sideAB) + (sideBC * sideBC) - (2 * sideAB * sideBC * Math.Cos(AngleB)));
            AngleA = Math.Acos(((SideAB * SideAB) + (SideAC * SideAC) - (SideBC * SideBC)) / (2 * SideAB * SideAC));
            AngleC = Math.Acos(((SideBC * SideBC) + (SideAC * SideAC) - (SideAB * SideAB)) / (2 * SideBC * SideAC));
        }

        public Triangle(double side)
        {
            SideAB = side;
            SideBC = side;
            SideAC = side;
            AngleA = Math.PI / 3;
            AngleB = AngleA;
            AngleC = AngleA;
        }

        //uses Heron's formula for area evaluation
        public override double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - SideAB) * (p - SideBC) * (p - SideAC));
        }

        public override double GetPerimeter()
        {
            return SideAB + SideBC + SideAC;
        }

        public double SideAB
        {
            get { return sideAB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "sideAB", "must be more than 0.");
                }
                else { sideAB = value; }
            }
        }
        public double SideBC
        {
            get { return sideBC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "sideBC", "must be more than 0.");
                }
                else { sideBC = value; }
            }
        }
        public double SideAC
        {
            get { return sideAC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "sideAC", "must be more than 0.");
                }
                else { sideAC = value; }
            }
        }
        public double AngleA
        {
            get { return angleA; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "angleA", "must be more than 0.");
                }
                else if (value >= Math.PI)
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleA", "must be less than PI (180 deg).");
                }
                else { angleA = value; }
            }
        }
        public double AngleB
        {
            get { return angleB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "angleB", "must be more than 0.");
                }
                else if (value >= Math.PI)
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleB", "must be less than PI (180 deg).");
                }
                else { angleB = value; }
            }
        }
        public double AngleC
        {
            get { return angleC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "angleC", "must be more than 0.");
                }
                else if (value >= Math.PI)
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleC", "must be less than PI (180 deg).");
                }
                else { angleC = value; }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    class Trapezoid : Figure
    {
        private double trapezBaseAB;
        private double trapezBaseCD;
        private double height;
        private double sideBC;
        private double sideAD;
        private double radAngleC;
        private double radAngleD;

        public Trapezoid(double trapezBaseAB, double trapezBaseCD, double height) //Wrong angle behavior for AB > CD
        {
            //TODO: fix angle evaluation for AB > CD
            TrapezBaseAB = trapezBaseAB;
            TrapezBaseCD = trapezBaseCD;
            if (TrapezBaseAB == TrapezBaseCD)
            {
                Console.WriteLine("This Trapezoid forbade itself from becoming a rectangle.");
                throw new Exception("Creation of trapezoid with even bases is forbidden");
            }
            Height = height;
            RadAngleC = Math.Atan(Height / (0.5 * Math.Abs(trapezBaseAB - trapezBaseCD)));
            RadAngleD = RadAngleC;
            SideBC = Height / (Math.Sin(RadAngleC));
            SideAD = Height / (Math.Sin(RadAngleD));
        }
        public Trapezoid(double trapezBase, string baseName, double height, double radAngleC, double radAngleD, string angleType) // angleType could be boolean
        {
            //converts angle value to radians, throws exceptions if angleType has a typo
            if (angleType.ToLower().Trim() == "deg")
            {
                radAngleC = (Math.PI / 180) * radAngleC;
                radAngleD = (Math.PI / 180) * radAngleD;
            }
            else if (angleType.ToLower().Trim() != "rad")
            {
                Console.WriteLine("type 'deg' or 'rad' for angle");
                throw new Exception("Wrong angle type argument");
            }

            Height = height;
            RadAngleC = radAngleC;
            RadAngleD = radAngleD;
            if ((RadAngleC == Math.PI / 2) & (RadAngleD == Math.PI / 2))
            {
                Console.WriteLine("This Trapezoid forbade itself from becoming a rectangle.");
                throw new Exception("Trapezoid has two right angles");
            }
            SideBC = Height / (Math.Sin(RadAngleC));
            SideAD = Height / (Math.Sin(RadAngleD));

            if (baseName.ToLower().Trim() == "ab")
            {
                TrapezBaseAB = trapezBase;
                double evaluation = TrapezBaseAB + (Math.Cos(RadAngleC) * SideBC) + (Math.Cos(RadAngleD) * SideAD);
                if (evaluation > 0) { TrapezBaseCD = evaluation; } 
                else
                {
                    throw new Exception("Trapezoid does not exist");
                }
            }
            else if (baseName.ToLower().Trim() == "cd")
            {
                TrapezBaseCD = trapezBase;
                double evaluation = TrapezBaseAB - (Math.Cos(RadAngleC) * SideBC) + (Math.Cos(RadAngleD) * SideAD);
                if (evaluation > 0) { TrapezBaseAB = evaluation; }
                else
                {
                    throw new Exception("Trapezoid does not exist");
                }
            }
            else
            {
                Console.WriteLine("type 'AB' or 'CD' for base");
                throw new Exception("Wrong base name argument");
            }
        }

        public override double GetArea()
        {
            return (TrapezBaseAB + TrapezBaseCD) * 0.5 * Height;
        }

        public override double GetPerimeter()
        {
            return TrapezBaseAB + TrapezBaseCD + SideAD + SideBC;
        }

        public double TrapezBaseAB
        {
            get { return trapezBaseAB; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "trapezBaseAB", "must be more than 0.");
                }
                else { trapezBaseAB = value; }
            }
        }
        public double TrapezBaseCD
        {
            get { return trapezBaseCD; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "trapezBaseCD", "must be more than 0.");
                }
                else { trapezBaseCD = value; }
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Height", "must be more than 0.");
                }
                else { height = value; }
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
        public double SideAD
        {
            get { return sideAD; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "sideAD", "must be more than 0.");
                }
                else { sideAD = value; }
            }
        }
        public double RadAngleC
        {
            get { return radAngleC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleC", "must be more than 0.");
                }
                else if (value > (Math.PI / 2))
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleC", "must be <= PI/2 (90 deg).");
                }
                else { radAngleC = value; }
            }
        }
        public double RadAngleD
        {
            get { return radAngleD; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleD", "must be more than 0.");
                }
                else if (value > (Math.PI / 2))
                {
                    throw new ArgumentOutOfRangeException(
                        "AngleD", "must be <= PI/2 (90 deg).");
                }
                else { radAngleD = value; }
            }
        }
        


    }
}

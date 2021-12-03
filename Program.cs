using System;
using System.Collections.Generic;
using System.Reflection;

namespace Homework_1
{
    class Program
    {
        public static ICollection<Figure> handsomeFiguresCollection = new List<Figure>();

        static void Main(string[] args)
        {
            handsomeFiguresCollection.Add(new Rectangle(4, 2));
            handsomeFiguresCollection.Add(new Circle(4));
            handsomeFiguresCollection.Add(new Square(5));
            handsomeFiguresCollection.Add(new Trapezoid(2, 4, 3));
            handsomeFiguresCollection.Add(new Trapezoid(4, 2, 3));
            handsomeFiguresCollection.Add(new Trapezoid(5, "AB", 4, (Math.PI / 3), (Math.PI / 4), "Rad"));
            handsomeFiguresCollection.Add(new Trapezoid(5, "CD", 4, 20, 10, "Deg"));
            handsomeFiguresCollection.Add(new Trapezoid(5, "CD", 4, 90, 10, "deg"));
            handsomeFiguresCollection.Add(new Triangle(2));
            handsomeFiguresCollection.Add(new Triangle(3, 4, 5));
            handsomeFiguresCollection.Add(new Triangle(2, 4, (Math.PI / 6), "rad"));
            handsomeFiguresCollection.Add(new Triangle(1, 3, 75, "deg"));

            Console.WriteLine("Sum of areas = " + SumAreas(handsomeFiguresCollection));
            Console.WriteLine("Sum of perimeters = " + SumPerimeters(handsomeFiguresCollection) + Environment.NewLine);

            bool isForFun = true;
            //Just for fun and values checking
            if (isForFun)
            {
                foreach (var figure in handsomeFiguresCollection)
                {
                    Console.WriteLine(new string('~', Console.WindowWidth));
                    Console.WriteLine(figure.ToString().Substring(figure.ToString().IndexOf('.') + 1) + Environment.NewLine);
                    foreach (PropertyInfo prop in figure.GetType().GetProperties())
                    {
                        Console.WriteLine(prop + " = " + prop.GetValue(figure, null).ToString());
                    }
                    Console.WriteLine("Perimeter = " + figure.GetPerimeter());
                    Console.WriteLine("Area = " + figure.GetArea());
                }
                Console.WriteLine(new string('~', Console.WindowWidth));
            }
            
        }

        public static double SumPerimeters(ICollection<Figure> collection)
        {
            double perimeter = 0;
            try
            {
                foreach (Figure figure in collection)
                {
                    perimeter += figure.GetPerimeter();
                }
                return perimeter;
            }
            catch (Exception e)
            {
                Console.WriteLine("Collections contains figures without perimeter definition (dot, line, ray, curve, etc.)");
                if (e.Source != null)
                {
                    Console.WriteLine("IOException source: {0}", e.Source);
                }
                throw; 
            }
        }

        public static double SumAreas(ICollection<Figure> collection)
        {
            double area = 0;
            try
            {
                foreach (Figure figure in collection)
                {
                    area += figure.GetArea();
                }
                if (area == 0)
                {
                    Console.WriteLine("Collection is empty, returns 0\n");
                }
                return area;
            }
            catch (Exception e)
            {
                Console.WriteLine("Collections contains figures without area definition (dot, line, ray, curve, etc.)");
                if (e.TargetSite != null)
                {
                    Console.WriteLine("IOException source: {0}", e.TargetSite);
                }
                throw;
            }
        }
    }
}

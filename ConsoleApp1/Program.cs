using System;
using Triangles;
using Points;
using System.Diagnostics;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Point[] Triangle1vertices = new Point[] {new Point(new double[] {1,4}), new Point(new double[] {1,1}), new Point(new double[] {5,1}) };
            Triangle triangle1 =  new Triangle(Triangle1vertices); 
            if (IsRectangle(triangle1))
            {
                triangle1 = new RectangularTriangle(Triangle1vertices);
            }
            Point[] Triangle2vertices = new Point[] { new Point(new double[] { 8, 7 }), new Point(new double[] { 11, 12 }), new Point(new double[] { 5, 4 }) };
            Triangle triangle2 = new Triangle(Triangle2vertices);
            if (IsRectangle(triangle2))
            {
                triangle2 = new RectangularTriangle(Triangle2vertices);
            }
            Point[] Triangle3vertices = new Point[] { new Point(new double[] { 7, 7 }), new Point(new double[] { 31, 25 }), new Point(new double[] { 14, 12 }) };
            Triangle triangle3 = new Triangle(Triangle3vertices);
            if (IsRectangle(triangle3))
            {
                triangle3 = new RectangularTriangle(Triangle3vertices);
            }
            Point[] Triangle4vertices = new Point[] { new Point(new double[] { 8, 7 }), new Point(new double[] { 11, 12 }), new Point(new double[] { 5, 4 }) };
            Triangle triangle4 = new Triangle(Triangle4vertices);
            if (IsRectangle(triangle4))
            {
                triangle4 = new RectangularTriangle(Triangle4vertices);
            }
            Point[] Triangle5vertices = new Point[] { new Point(new double[] { 15, 7 }), new Point(new double[] { 11, 12 }), new Point(new double[] { 17, 11 }) };
            Triangle triangle5 = new Triangle(Triangle5vertices);
            if (IsRectangle(triangle5))
            {
                triangle5 = new RectangularTriangle(Triangle5vertices);
            }
            double wholearea = triangle1.TriangleArea() + triangle2.TriangleArea() + triangle3.TriangleArea() + triangle4.TriangleArea() + triangle5.TriangleArea(); 
            stopwatch.Stop();
            Console.WriteLine("Area:" + wholearea);
            Console.WriteLine("Number of rectangular triangles:" + RectangularTriangle.Number_of_rect);
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
        static bool IsRectangle(Triangle triangle)
        {
            double summ = 0;
            List <double> sides = triangle.Sides();
            double max_side = sides.Max();
            foreach (double side in sides)
            {

                if (side != max_side)
                {
                    summ += Math.Pow(side, 2);
                }
            }
            if (summ == Math.Pow(max_side, 2))
            {
                return true;
            }
            else { return false; }
        }
    }
 }
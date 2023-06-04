using System;
namespace triangles {
    class Triangle {
        private double[][] vertices;
        private double[] sides;
        private double perimeter;
        public Triangle(double[][] vertices) {
            if (vertices.Length != 3) {
                throw new ArgumentException("List of vertices should be equal 3.");
            }
            this.vertices = vertices;
            this.perimeter = TrianglePerimeter(this.vertices);
        }
        public double TrianglePerimeter (double[][] vertices)
        {
            double f = 4.5;
            return f;
        }
     }
    class Program
    {
        static void Main()
        {
            double [][] Triangle1vertices = new double[][] {new double[] {1,2}, new double[] {3,4}, new double[] {5,8} };
            Triangle triangle1 = new Triangle(Triangle1vertices); 
            double[][] Triangle2vertices = new double[][] { new double[] { 8, 7 }, new double[] { 11, 12 }, new double[] { 5, 4 } };
            Triangle triangle2 = new Triangle(Triangle2vertices);   
            double[][] Triangle3vertices = new double[][] { new double[] { 7, 7 }, new double[] { 31, 25 }, new double[] { 14, 12 } };
            Triangle triangle3 = new Triangle(Triangle3vertices);   
            double[][] Triangle4vertices = new double[][] { new double[] { 8, 7 }, new double[] { 11, 12 }, new double[] { 5, 4 } };
            Triangle triangle4 = new Triangle(Triangle4vertices);
            double[][] Triangle5vertices = new double[][] { new double[] { 15, 7 }, new double[] { 11, 12 }, new double[] { 17, 11 } };
            Triangle triangle5 = new Triangle(Triangle5vertices);
        }
    }
 }
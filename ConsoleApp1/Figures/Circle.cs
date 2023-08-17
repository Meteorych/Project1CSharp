using System;
using System.Drawing;



namespace ConsoleApp1.Figures
{

    class Circle : Figure
    {

        private double radius;

        public Circle(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            radius = Convert.ToInt32(string.Concat(vertices[1].Coordinates));
            double[] center = vertices[0].Coordinates;
        }

        public override double GetArea()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

    }
}

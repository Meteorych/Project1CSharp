using System;
using System.Collections.Generic;
using System.Drawing;
using Figures;

namespace Qudrangles
{
    class Quadrangle : Figure
    {
        private Points.Point[] vertices;
        private List<Double> sides;
        private int numOfSides = 4;
        public Quadrangle(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            //Передавать вершины в порядке следования
            this.vertices = vertices;
            this.sides = MakingSides();

        }
        public List<double> MakingSides()
        {
            List<double> sides = new List<double>();
            for (int i = 0; i < numOfSides; i++)
            {

                int j = (i + 1) % numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(this.vertices[j].Coordinates[0] - this.vertices[i].Coordinates[0], 2) + Math.Pow(this.vertices[j].Coordinates[1] - this.vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }
        public override double GetArea()
        {
            this.sides = MakingSides();
            return sides[0] * sides[1];
        }
    }
    class Square : Quadrangle
    {

        public Square(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

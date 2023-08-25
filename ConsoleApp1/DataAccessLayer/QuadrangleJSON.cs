using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1.DataAccessLayer
{
    class QuadrangleJSON : FigureJSON
    {
        private Points.Point[] vertices;
        private List<double> sides;
        private int numOfSides = 4;
        public QuadrangleJSON(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            //Передавать вершины в порядке следования
            this.vertices = vertices;
            sides = MakingSides();

        }
        public List<double> MakingSides()
        {
            List<double> sides = new List<double>();
            for (int i = 0; i < numOfSides; i++)
            {

                int j = (i + 1) % numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(vertices[j].Coordinates[0] - vertices[i].Coordinates[0], 2) + Math.Pow(vertices[j].Coordinates[1] - vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }
        public override double GetArea()
        {
            sides = MakingSides();
            return sides[0] * sides[1];
        }
    }

    class SquareDAL : QuadrangleJSON
    {

        public SquareDAL(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

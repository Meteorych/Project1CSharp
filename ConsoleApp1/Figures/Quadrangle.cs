using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1.Figures
{
    /// <summary>
    /// Quadrangle figure.
    /// </summary>
    class Quadrangle : Figure
    {
        private Vertex.Point[] _vertices;
        private List<double> _sides;
        private const int _numOfSides = 4;
        public Quadrangle(Vertex.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            //Передавать вершины в порядке следования
            this._vertices = vertices;
            _sides = MakingSides();

        }
        public List<double> MakingSides()
        {
            List<double> sides = new List<double>();
            for (int i = 0; i < _numOfSides; i++)
            {

                int j = (i + 1) % _numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(_vertices[j].Coordinates[0] - _vertices[i].Coordinates[0], 2) + Math.Pow(_vertices[j].Coordinates[1] - _vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }
        public override double GetArea()
        {
            _sides = MakingSides();
            return _sides[0] * _sides[1];
        }
    }
    /// <summary>
    /// Square figure.
    /// </summary>
    class Square : Quadrangle
    {

        public Square(Vertex.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

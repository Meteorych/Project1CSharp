using System.Drawing;
using System.Text.Json.Serialization;

namespace ConsoleApp1.DataAccessLayer
{
    //Создание объекта треугольник с помощью наследуемого класса от родителького класса Figure
    class TriangleJSON : FigureJSON
    {

        private const int numOfSides = 3;

        public TriangleJSON(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            if (vertices.Length != numOfSides)
            {
                throw new ArgumentException("List of vertices should be " + numOfSides);
            }
            Vertices = vertices;
        }
    }
    class RectangularTriangleJSON : TriangleJSON
    {
        public RectangularTriangleJSON(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

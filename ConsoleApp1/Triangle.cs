using System.Drawing;
using System.Text.Json.Serialization;
using Figures;
namespace Triangles
{
    //Создание объекта треугольник с помощью наследуемого класса от родителького класса Figure
    class Triangle : Figure
    {
        
        private const int numOfSides = 3;
        
        public Triangle(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {   
            if (vertices.Length != numOfSides)
            {
                throw new ArgumentException("List of vertices should be ." + numOfSides);
            }
            Vertices = vertices;
        }

        //Расчёт длины сторон
        public List<double> Sides()
        {
            List <double> sides = new List<double>();
            for (int i = 0; i < numOfSides; i++)
            {
                int j = (i + 1) % numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(this.Vertices[j].Coordinates[0] - this.Vertices[i].Coordinates[0], 2) + Math.Pow(this.Vertices[j].Coordinates[1] - this.Vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }

        //перегруженная из родительского класса фукнция, возвращающая площадь треугольника
        public override double GetArea()
        {
            List<double> sides = Sides();
            return 0.5 * Math.Abs((this.Vertices[1].Coordinates[0] - this.Vertices[0].Coordinates[0]) * (this.Vertices[2].Coordinates[1] - this.Vertices[0].Coordinates[1]) - (this.Vertices[2].Coordinates[0] - this.Vertices[0].Coordinates[0]) * (this.Vertices[1].Coordinates[1] - this.Vertices[0].Coordinates[1]));
        }
    }
    class RectangularTriangle : Triangle
    {
        public RectangularTriangle(Points.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            
        }
    }
}

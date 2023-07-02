using System.Drawing;
using Figures;
namespace Triangles
{
    //Создание объекта треугольник с помощью наследуемого класса от родителького класса Figure
    class Triangle : Figure
    {
        private Points.Point[] vertices;
        private List<double> sides;
        private int numOfSides = 3; 
        public Triangle(Points.Point[] vertices, Color color) : base(vertices, color) 
        {
            if (vertices.Length != numOfSides)
            {
                throw new ArgumentException("List of vertices should be equal 3.");
            }
            this.vertices = vertices;
            sides = Sides();

        }
        //Расчёт длины сторон
        
        public List<double> Sides()
        {
            List <double> sides = new List<double>();
            for (int i = 0; i < numOfSides; i++)
            {
                int j = (i + 1) % numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(this.vertices[j].Coordinates[0] - this.vertices[i].Coordinates[0], 2) + Math.Pow(this.vertices[j].Coordinates[1] - this.vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }
        //перегруженная из родительского класса фукнция, вовзращающая площадь треугольника
        public override double GetArea()
        {
            sides = Sides();
            return 0.5 * Math.Abs((this.vertices[1].Coordinates[0] - this.vertices[0].Coordinates[0]) * (this.vertices[2].Coordinates[1] - this.vertices[0].Coordinates[1]) - (this.vertices[2].Coordinates[0] - this.vertices[0].Coordinates[0]) * (this.vertices[1].Coordinates[1] - this.vertices[0].Coordinates[1]));
        }
    }
    class RectangularTriangle : Triangle
    {
    
        public RectangularTriangle(Points.Point[] vertices, Color color ) : base(vertices, color) 
        {
            
        }
    }
}

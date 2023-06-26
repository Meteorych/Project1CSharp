using System;
using Program;
using Points;
using Figures;
namespace Triangles
{
    //Создание объекта треугольник с помощью наследуемого класса от родителького класса Figure
    class Triangle : Figure
    {
        private Vertex[] vertices;
        private List<double> sides;
        public Triangle(Vertex[] vertices ) : base(vertices) 
        {
            if (vertices.Length != 3)
            {
                throw new ArgumentException("List of vertices should be equal 3.");
            }
            this.vertices = vertices;
            this.sides = Sides();
       
        }
        //Расчёт длины сторон
        
        public List<double> Sides()
        {
            List <double> sides = new List<double>();
            for (int i = 0; i < 3; i++)
            {
                int j = (i + 1) % 3;
                sides.Add(Math.Sqrt(Math.Pow(this.vertices[j].Pointcords[0] - this.vertices[i].Pointcords[0], 2) + Math.Pow(this.vertices[j].Pointcords[1] - this.vertices[i].Pointcords[1], 2)));
            }
            return sides;
        }
        //перегруженная из родительского класса фукнция, вовзращающая площадь треугольника
        public override double GetArea()
        {
            double area = 0;
            return 0.5 * Math.Abs((this.vertices[1].Pointcords[0] - this.vertices[0].Pointcords[0]) * (this.vertices[2].Pointcords[1] - this.vertices[0].Pointcords[1]) - (this.vertices[2].Pointcords[0] - this.vertices[0].Pointcords[0]) * (this.vertices[1].Pointcords[1] - this.vertices[0].Pointcords[1]));
            //Console.WriteLine(area);
        }
    }
    class RectangularTriangle : Triangle
    {
        private static int numofrecttriangles = 0;
        public RectangularTriangle(Vertex[] vertices ) : base(vertices) 
        {
            numofrecttriangles++;
        }
        public static string Number_of_rect
        {
            get { return numofrecttriangles.ToString(); }
        }
    }
}

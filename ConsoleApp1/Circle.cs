using System.Drawing;
using Figures;

namespace Circles
{
    class Circle : Figure
    {
        private double radius;
        private double[] center;
        //Переписать под центр/радиус
        public Circle(Points.Point[] vertices, Color color) : base(vertices, color)
        {
            radius = Convert.ToInt32(string.Concat(vertices[1].Coordinates));
            center = vertices[0].Coordinates;
        }

        public override double GetArea()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

    }
}

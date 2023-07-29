using System.Drawing;
using Points;
using System.Text.Json.Serialization;

namespace Figures
{
    //Родительский класс для всех фигур
    abstract class Figure
    {
        public Color LineColor { get; set; }
        public Color FillColor { get; set; }
        public Points.Point[] Vertices { get; set; }

        public Figure(Points.Point[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }
        public abstract double GetArea();
    }
    
}

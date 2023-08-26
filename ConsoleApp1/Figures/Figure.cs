using System.Drawing;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace ConsoleApp1.Figures
{


    //Parent class for all figures
    abstract class Figure
    {
        
        public Color LineColor { get; set; }

        public Color FillColor { get; set; }
        public Vertex.Point[] Vertices { get; set; }

        public Figure(Vertex.Point[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }

        public abstract double GetArea();
        
    }

}

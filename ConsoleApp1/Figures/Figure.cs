using System.Drawing;
using Points;
using System.ComponentModel;
using Triangles;
using Qudrangles;
using Circles;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using IRepository;

namespace ConsoleApp1.Figures
{


    //Родительский класс для всех фигур
    abstract class Figure
    {
        //Попробовать реализовать Data Access Layer
        public Color LineColor { get; set; }

        public Color FillColor { get; set; }
        public Points.Point[] Vertices { get; set; }

        // Constructor for serialization and custom deserialization
        [JsonConstructor]
        public Figure(Points.Point[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }

        public abstract double GetArea();
    }

}

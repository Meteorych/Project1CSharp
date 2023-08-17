using ConsoleApp1.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;


namespace FigureJSON
{
    [JsonDerivedType(typeof(Triangle), typeDiscriminator: "Triangle")]
    [JsonDerivedType(typeof(RectangularTriangle), typeDiscriminator: "RectTriangle")]
    [JsonDerivedType(typeof(Circle), typeDiscriminator: "Circle")]
    [JsonDerivedType(typeof(Quadrangle), typeDiscriminator: "Quadrangle")]
    [JsonDerivedType(typeof(Square), typeDiscriminator: "Square")]
    class FigureJSON
    {
        public Color LineColor { get; set; }
        public Color FillColor { get; set; }
        public Points.Point[] Vertices { get; set; }

        // Constructor for serialization and custom deserialization
        [JsonConstructor]
        public FigureJSON(Points.Point[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }
    }
}

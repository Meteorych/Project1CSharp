using ConsoleApp1.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace ConsoleApp1.DataAccessLayer
{
    [JsonDerivedType(typeof(TriangleJSON), typeDiscriminator: "Triangle")]
    [JsonDerivedType(typeof(RectangularTriangleJSON), typeDiscriminator: "RectTriangle")]
    [JsonDerivedType(typeof(CircleJSON), typeDiscriminator: "Circle")]
    [JsonDerivedType(typeof(QuadrangleJSON), typeDiscriminator: "Quadrangle")]
    [JsonDerivedType(typeof(SquareJSON), typeDiscriminator: "Square")]
    class FigureJSON
    {
        public Color LineColor { get; set; }
        public Color FillColor { get; set; }
        public PointJSON[] Vertices { get; set; }

        public FigureJSON(PointJSON[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }
    }
}


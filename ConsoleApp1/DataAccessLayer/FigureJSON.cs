using ConsoleApp1.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccessLayer
{
    [JsonDerivedType(typeof(TriangleJSON), typeDiscriminator: "Triangle")]
    [JsonDerivedType(typeof(RectangularTriangleJSON), typeDiscriminator: "RectTriangle")]
    [JsonDerivedType(typeof(CircleJSON), typeDiscriminator: "Circle")]
    [JsonDerivedType(typeof(QuadrangleJSON), typeDiscriminator: "Quadrangle")]
    [JsonDerivedType(typeof(SquareDAL), typeDiscriminator: "Square")]
    class FigureJSON
    {
        public Color LineColor { get; set; }
        public Color FillColor { get; set; }
        public Points.Point[] Vertices { get; set; }

        public FigureJSON(Points.Point[] vertices, Color lineColor, Color fillColor)
        {
            Vertices = vertices;
            LineColor = lineColor;
            FillColor = fillColor;
        }
    }
}


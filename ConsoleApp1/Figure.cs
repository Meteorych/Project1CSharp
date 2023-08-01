using System.Drawing;
using Points;
using System.ComponentModel;
using Triangles;
using Qudrangles;
using Circles;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;


namespace Figures
{

    [JsonDerivedType(typeof(Triangle), typeDiscriminator: "Triangle")]
    [JsonDerivedType(typeof(RectangularTriangle), typeDiscriminator:"RectTriangle")]
    [JsonDerivedType(typeof(Circle), typeDiscriminator: "Circle")]
    [JsonDerivedType(typeof(Quadrangle), typeDiscriminator: "Quadrangle")]
    [JsonDerivedType(typeof(Square), typeDiscriminator: "Square")]
    //Родительский класс для всех фигур
    class Figure
    {
        
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

        public virtual double GetArea()
        { return 0; }
    }
    
}

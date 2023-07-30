using System.Drawing;
using Points;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Figures
{ 
    //Родительский класс для всех фигур
    abstract class Figure
    {
        [JsonIgnore] // Ignore these properties during serialization
        public Color LineColor { get; set; }

        [JsonIgnore] // Ignore these properties during serialization
        public Color FillColor { get; set; }

        [JsonPropertyName("lineColor")]
        public string LineColorString
        {
            get => ColorTranslator.ToHtml(LineColor);
            set => LineColor = ColorTranslator.FromHtml(value);
        }

        [JsonPropertyName("fillColor")]
        public string FillColorString
        {
            get => ColorTranslator.ToHtml(FillColor);
            set => FillColor = ColorTranslator.FromHtml(value);
        }
        
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

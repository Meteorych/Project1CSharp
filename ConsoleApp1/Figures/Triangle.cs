using System.Drawing;
using System.Text.Json.Serialization;

namespace ConsoleApp1.Figures
{
    /// <summary>
    /// Triangle figure.
    /// </summary>
    class Triangle : Figure
    {

        private const int numOfSides = 3;

        public Triangle(Vertex.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            if (vertices.Length != numOfSides)
            {
                throw new ArgumentException("List of vertices should be ." + numOfSides);
            }
            Vertices = vertices;
        }

        /// <summary>
        /// Calculating the length of each side.
        /// </summary>
        /// <returns>List with lenghts of sides.</returns>
        public List<double> Sides()
        {
            List<double> sides = new List<double>();
            for (int i = 0; i < numOfSides; i++)
            {
                int j = (i + 1) % numOfSides;
                sides.Add(Math.Sqrt(Math.Pow(Vertices[j].Coordinates[0] - Vertices[i].Coordinates[0], 2) + Math.Pow(Vertices[j].Coordinates[1] - Vertices[i].Coordinates[1], 2)));
            }
            return sides;
        }

        /// <summary>
        /// Calculating area of triangle.
        /// </summary>
        /// <returns>Area of triangle</returns>
        public override double GetArea()
        {
            List<double> sides = Sides();
            return 0.5 * Math.Abs((Vertices[1].Coordinates[0] - Vertices[0].Coordinates[0]) * (Vertices[2].Coordinates[1] - Vertices[0].Coordinates[1]) - (Vertices[2].Coordinates[0] - Vertices[0].Coordinates[0]) * (Vertices[1].Coordinates[1] - Vertices[0].Coordinates[1]));
        }
    }
    class RectangularTriangle : Triangle
    {
        /// <summary>
        /// Rectangelar triangle figure.
        /// </summary>
        public RectangularTriangle(Vertex.Point[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

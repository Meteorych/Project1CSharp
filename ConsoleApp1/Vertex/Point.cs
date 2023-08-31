using System.Text.Json.Serialization;

namespace ConsoleApp1.Vertex
{

    class Point
    {
        public Point(double[] coordinates)
        {
            Coordinates = coordinates;
            Dimension = coordinates.Length;

        }
        public double[] Coordinates { get; }
        public int Dimension { get; }
    }
}



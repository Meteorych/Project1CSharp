using System.Text.Json.Serialization;
namespace Points
{
    
    class Point
    {
        
        [JsonConstructor]
        public Point(double[] coordinates, int dimension)
        {

            Coordinates = coordinates;
            Dimension = dimension;

        }

        public Point(double[] pointCords)
        {

            Coordinates = pointCords;
            Dimension = pointCords.Length;

        }
        public double[] Coordinates { get; set; }
        public int Dimension { get; set; }
    }
}



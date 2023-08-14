using System.Text.Json.Serialization;
namespace Points
{
    
    class Point
    {
        
        [JsonConstructor]
        public Point(double[] pointCords)
        {
            Coordinates = pointCords;
            Dimension = pointCords.Length;

        }
        public double[] Coordinates { get; }
        public int Dimension { get; }
    }
}



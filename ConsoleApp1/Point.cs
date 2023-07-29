using System.Text.Json.Serialization;
namespace Points
{
    
    class Point
    {

        public Point(double[] pointCords)
           {

            Coordinates = pointCords;
            Dimension = pointCords.Length;

        }
        [JsonPropertyName("Coordinates")]
        public double [] Coordinates { get; set; }
        public int Dimension { get; set; }
    }
}



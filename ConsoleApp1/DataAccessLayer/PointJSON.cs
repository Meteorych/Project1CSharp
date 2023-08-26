using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ConsoleApp1.DataAccessLayer
{
    class PointJSON
    {
        
        public PointJSON(double[] coordinates)
        {
            Coordinates = coordinates;
            Dimension = coordinates.Length;

        }
        public double[] Coordinates { get; }
        public int Dimension { get; }
    }
}


﻿namespace Points
{
    
    class Point
    {
        public Point(double[] pointCords)
            {

            Coordinates = pointCords;
            Dimension = pointCords.Length;

        }
        public double [] Coordinates { get ;  }
        public int Dimension { get; }
    }
}



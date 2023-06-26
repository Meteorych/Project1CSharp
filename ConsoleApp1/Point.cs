using System;

namespace Points
{
    
    class Vertex
    {
        private double[] pointcords;
        public Vertex(double[] pointcords)
            {
            if (pointcords.Length != 2 && pointcords.Length != 3)
            {
                throw new ArgumentException("Amount of coordinates is wrong");
            }
            this.pointcords = pointcords;
        }
        public double [] Pointcords { get { return pointcords; } }
        
    }
}



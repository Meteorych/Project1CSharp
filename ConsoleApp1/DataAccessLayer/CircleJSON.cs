using System;
using System.Drawing;



namespace ConsoleApp1.DataAccessLayer
{

    class CircleJSON : FigureJSON
    {
        public CircleJSON(PointJSON[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

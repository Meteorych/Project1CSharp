using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1.DataAccessLayer
{
    class QuadrangleJSON : FigureJSON
    {
        
        public QuadrangleJSON(PointJSON[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {
            
        }
    }

    class SquareJSON : QuadrangleJSON
    {

        public SquareJSON(PointJSON[] vertices, Color lineColor, Color fillColor) : base(vertices, lineColor, fillColor)
        {

        }
    }
}

using System.Drawing;
using Points;

namespace Figures
{
    //Родительский класс для всех фигур
    abstract class Figure
    {
        protected Color lineColor;
        protected Color fillColor;

        public Figure(Points.Point[] vertices, Color lineColor, Color fillColor)
        {

            this.lineColor = lineColor;
            this.fillColor = fillColor;
        }
        public abstract double GetArea();
    }
    
}

﻿using System.Drawing;
using Points;

namespace Figures
{
    //Родительский класс для всех фигур
    abstract class Figure
    {
        protected Color color;
        public Figure(Points.Point[] vertices, Color chosenColor)
        {
          
            color = chosenColor;
        }
        public abstract double GetArea();
    }
    
}
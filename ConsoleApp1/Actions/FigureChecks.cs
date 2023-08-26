﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Figures;

namespace ConsoleApp1.Actions
{
    class FiguresCheck
    {
        public bool IsRectangle(Triangle triangle)
        {
            double summ = 0;
            List<double> sides = triangle.Sides();
            double max_side = sides.Max();
            foreach (double side in sides)
            {

                if (side != max_side)
                {
                    summ += Math.Pow(side, 2);
                }
            }
            if (summ == Math.Pow(max_side, 2))
            {
                return true;
            }
            else { return false; }
        }
    }
}
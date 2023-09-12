using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Figures;

namespace ConsoleApp1.Actions
{
    /// <summary>
    /// Different checks of figures.
    /// </summary>
    class FiguresCheck
    {
        /// <summary>
        /// Checking if triangle is rectangle.
        /// </summary>
        /// <param name="triangle">Checked triangle</param>
        /// <returns>"False" or "true" to the assumption that triangle is rectangle </returns>
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

            return (Math.Abs(summ - Math.Pow(max_side, 2)) < double.Epsilon);
        }
    }
}

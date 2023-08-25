using ConsoleApp1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccessLayer
{
    class DALParser
    {
        public List<Figure> CreateIsntance(List<FigureJSON> figures)
        {
            List<Figure> result = new List<Figure>();
            foreach (FigureJSON figure in figures) { 
                if (figure.GetType().Name == "TriangleJSON")
                {
                    result.Add(new Triangle(figure.Vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "CircleJSON")
                {
                    result.Add(new Circle(figure.Vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "RectangularTriangleJSON")
                {
                    result.Add(new RectangularTriangle(figure.Vertices, figure.LineColor, figure.FillColor));
                }
                else if (figure.GetType().Name == "QudrangleJSON")
                {
                    result.Add(new Quadrangle(figure.Vertices, figure.LineColor, figure.FillColor));
                }
                else
                {
                    result.Add(new Square(figure.Vertices, figure.LineColor, figure.FillColor));
                }
             }
            return result;
        }
    }
}

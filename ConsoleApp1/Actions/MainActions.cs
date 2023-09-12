using System.Drawing;
using System.Text.RegularExpressions;
using ConsoleApp1.Figures;

namespace ConsoleApp1.Actions
{
    class Action
    {


        public static Vertex.Point[] VerticeCreation(int numOfVertices, string coordinates)
        {
            Vertex.Point[] Figurevertices = new Vertex.Point[numOfVertices];
            for (int i = 0; i < numOfVertices; i++)
            {
                //Разбиваем координаты на список по вершинам, которые они обозначают 
                string[] listOfCoordinates = coordinates.Split(",");
                foreach (string line in listOfCoordinates)
                {
                    Figurevertices[i] = new Vertex.Point(new double[] { double.Parse(listOfCoordinates[i][0].ToString()), double.Parse(listOfCoordinates[i][1].ToString()) });
                }
            }
            return Figurevertices;
        }

        public static int CalcNumOfVertices(string coordinates)
        {
            Regex comma = new(@",");
            int numOfVertices = comma.Matches(coordinates).Count + 1;
            return numOfVertices;
        }

        public Figure FigureCreating(Color lineColor, Color fillColor, string coordinates)
        {

            int numOfVertices = CalcNumOfVertices(coordinates);

            Vertex.Point[] Figurevertices = VerticeCreation(numOfVertices, coordinates);

            if (numOfVertices == 2)
            {
                return new Circle(Figurevertices, lineColor, fillColor);
            }
            else if (numOfVertices == 3)
            {
                return TriangleCreation(Figurevertices, lineColor, fillColor);
            }
            else
            {
                Quadrangle quadrangle = new(Figurevertices, lineColor, fillColor);
                List<double> sides = quadrangle.MakingSides();
                bool SidesEqual = sides.All(x => x == sides[0]);
                if (SidesEqual)
                {
                    return new Square(Figurevertices, lineColor, fillColor);
                }
                else
                {
                    return quadrangle;
                }
            }
        }

        public static Triangle TriangleCreation(Vertex.Point[] vertices, Color lineColor, Color fillColor)
        {
            Triangle triangle = new(vertices, lineColor, fillColor);
            FiguresCheck check = new();
            if (check.IsRectangle(triangle))
            {
                return new RectangularTriangle(vertices, lineColor, fillColor);
            }
            else
            {
                return triangle;
            }
        }

    }
}

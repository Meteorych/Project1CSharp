﻿using System.Drawing;
using FiguresChecks;
using System.Text.RegularExpressions;
using ConsoleApp1.Figures;

namespace Actions
{
    class Action
    {
        private FiguresList figures;
        public Action(FiguresList figures) 
        {
            this.figures = figures;
        }

        public Points.Point[] VerticeCreation(int numOfVertices, string coordinates)
        {
            Points.Point[] Figurevertices = new Points.Point[numOfVertices];
            for (int i = 0; i < numOfVertices; i++)
            {
                //Разбиваем координаты на список по вершинам, которые они обозначают 
                string[] listOfCoordinates = coordinates.Split(",");
                foreach (string line in listOfCoordinates)
                {
                    Figurevertices[i] = new Points.Point(new double[] { double.Parse(listOfCoordinates[i][0].ToString()), double.Parse(listOfCoordinates[i][1].ToString()) });
                }
            }
            return Figurevertices;
        }

        public int CalcNumOfVertices(string coordinates)
        {
            Regex comma = new Regex(@",");
            int numOfVertices = comma.Matches(coordinates).Count + 1;
            return numOfVertices;
        }

        public Figure FigureCreating(Color lineColor, Color fillColor)
        {
            Console.WriteLine("Input coordinates of vertex in format like \"12,24,15\": ");
            string? coordinates;
            do
            {
                coordinates = Console.ReadLine();
            } while (string.IsNullOrEmpty(coordinates));

            Regex regex = new Regex(@"[^0-9,]");
            if (regex.Matches(coordinates).Count != 0 || (coordinates.Length == 0 || coordinates.Length == 1))
            {
                throw new FormatException("Wrong Format of coordinates");
            }

            int numOfVertices = CalcNumOfVertices(coordinates);

            Points.Point[] Figurevertices = VerticeCreation(numOfVertices, coordinates);
            
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
                Quadrangle quadrangle = new Quadrangle(Figurevertices, lineColor, fillColor);
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

        public TriangleJSON TriangleCreation(Points.Point[] vertices, Color lineColor, Color fillColor)
        {
            TriangleJSON triangle = new Triangle(vertices, lineColor, fillColor);
            FiguresCheck check = new FiguresCheck();
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

using System;
using System.Drawing;
using Figures;
using Checks;
using Qudrangles;
using Circles;
using Triangles;
using System.Text.RegularExpressions;
namespace Actions
{
    class Action
    {
        private List<Figure> figures;
        private bool endProgram;
        public Action(List <Figure> figures) {
            this.figures = figures;
            endProgram = false;
        }

        public bool EndProgram { get { return endProgram; } }

        //Пользователю даётся возможность выбирать из 4 возможных дейтсвий (Добавить фигуру, удалить фигуру, показать фигуры, общая площадь)
        public void ActionChoice()
        {
            Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area: ");
            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        FigureCreating();
                        break;
                    case 2:
                        DeletingFigure();
                        break;
                    case 3:
                        foreach (Figure f in figures)
                        {
                            Console.WriteLine(f.ToString() + " " + f.GetArea().ToString());
                        }
                        break;
                    case 4:
                        double area = 0;
                        foreach (Figure f in figures)
                        {
                            area += f.GetArea();
                        }
                        Console.WriteLine("Total area:" + area);
                        break;
                    default:
                        endProgram = true;
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Symbol!");
            }
        }

        public List<Figure> DeletingFigure()
        {
            Console.WriteLine("Input the number of figure you want to delete: ");
            int num = Convert.ToInt32(Console.ReadLine());
            figures.RemoveAt(num);
            return figures;
        }

        public Color ColorChoice()
        {
            Console.WriteLine("Input chosen color: ");
            try {
                Color chosenColor = Color.FromName(Console.ReadLine());
                return chosenColor;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong color!");
                throw;
            }
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

        public Figure FigureCreating()
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

            Color chosenColor = ColorChoice();
            
            if (numOfVertices == 2)
            {
                return new Circle(Figurevertices, chosenColor);
            }
            else if (numOfVertices == 3)
            {
                return TriangleCreation(Figurevertices, chosenColor);
            }
            else
            {
                Quadrangle quadrangle = new Quadrangle(Figurevertices, chosenColor);
                List<double> sides = quadrangle.MakingSides();
                bool SidesEqual = sides.All(x => x == sides[0]);
                if (SidesEqual)
                {
                    return new Square(Figurevertices, chosenColor);
                }
                else
                {
                    return quadrangle;
                }
            }
        }

        public Triangle TriangleCreation(Points.Point[] vertices, Color chosenColor)
        {
            Triangle triangle = new Triangle(vertices, chosenColor);
            Check check = new Check();
            if (check.IsRectangle(triangle))
            {
                return new RectangularTriangle(vertices, chosenColor);
            }
            else
            {
                return triangle;
            }

        }

    }
}

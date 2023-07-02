using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using Triangles;
using Figures;
using Circles;
using Points;
using Qudrangles;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<Figure> figures = new List<Figure>();
            while (true) {
                ///Пользователю даётся возможность выбирать из 4 возможных дейтсвий (Добавить фигуру, удалить фигуру, показать фигуры, общая площадь)
                Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area: ");
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            figures.Add(FigureCreating());
                            continue;
                        case 2:
                            Console.WriteLine("Input the number of figure you want to delete: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            figures.RemoveAt(num);
                            continue;
                        case 3:
                            foreach (Figure f in figures)
                            {
                                if (f is Triangle)
                                {
                                    Console.WriteLine("\nTraingle with area:" + f.GetArea());
                                }
                                else if (f is RectangularTriangle)
                                {
                                    Console.WriteLine("\nRectangular triangle with area: " + f.GetArea());
                                }
                                else if (f is Quadrangle)
                                {
                                    Console.WriteLine("\nQuadrangle with area: " + f.GetArea());
                                }
                                else if (f is Circle)
                                {
                                    Console.WriteLine("\nCircle with area: " + f.GetArea());
                                }
                                else if (f is Square)
                                {
                                    Console.WriteLine("\nSquare with area: " + f.GetArea());
                                }
                            }
                            continue;
                        case 4:
                            double area = 0;
                            foreach (Figure f in figures)
                            {
                                area += f.GetArea();
                                Console.WriteLine(f.GetArea());
                                Console.WriteLine("Total area:" + area);
                            }
                            continue;
                        default:
                            stopwatch.Stop();
                            Console.WriteLine(stopwatch.ElapsedMilliseconds);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong Symbol!");
                }

                
            }
        
            
        }
        static Figure FigureCreating()
        {

            Console.WriteLine("Input coordinates of vertex in format like \"12,24,15\": ");
            var coordinates = Console.ReadLine();
            Regex regex = new Regex(@"[^0-9,]");
            Regex comma = new Regex(@",");
            if (regex.Matches(coordinates).Count != 0 || (coordinates.Length == 0 || coordinates.Length == 1))
            {
                Console.WriteLine("Wrong format of coordinates!");
                return null;
            }
            int b = comma.Matches(coordinates).Count + 1;
            Points.Point[] Figurevertices = new Points.Point[b];
            int index_of_comma = 0;
            for (int i = 0; i < b; i++) 
            {
                int old_index = index_of_comma;
                index_of_comma = coordinates.IndexOf(",", old_index+1);
                if (index_of_comma == -1)
                {
                    Figurevertices[i] = new Points.Point(new double[] { double.Parse(coordinates[coordinates.Length - 2].ToString()), double.Parse(coordinates[coordinates.Length - 1].ToString()) });
                }
                else
                {
                    Figurevertices[i] = new Points.Point(new double[] { double.Parse(coordinates[index_of_comma - 2].ToString()), double.Parse(coordinates[index_of_comma - 1].ToString()) });
                }
            }
            Console.WriteLine("Choose a color for the figure:");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Blue");
            Console.WriteLine("3. Green");

            Color chosenColor;
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    chosenColor = Color.Red;
                    break;
                case 2:
                    chosenColor = Color.Blue;
                    break;
                case 3:
                    chosenColor = Color.Green;
                    break;
                default:
                    chosenColor = Color.Black;
                    break;
            }
            if (comma.Matches(coordinates).Count == 1)
            {
                return new Circle(Figurevertices, chosenColor);
            }
            else if (comma.Matches(coordinates).Count == 2)
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

        static Triangle TriangleCreation(Points.Point[] vertices, Color chosenColor)
        {
            Triangle triangle = new Triangle(vertices, chosenColor);
            if (IsRectangle(triangle))
            {
                return new RectangularTriangle(vertices, chosenColor);
            }
            else
            {
                return triangle;
            }
            
        }

        static bool IsRectangle(Triangle triangle)
        {
            double summ = 0;
            List <double> sides = triangle.Sides();
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
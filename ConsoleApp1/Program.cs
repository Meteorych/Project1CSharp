using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using Triangles;
using Figures;
using Points;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            List<Figure> figures = new List<Figure>();
            while (true) {
                Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area: ");
                try
                {
                    var choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            figures.Add(FigureCreating());
                            continue;
                        case 2:
                            Console.WriteLine("Input the number of figure you want to delete: ");
                            int num = Int32.Parse(Console.ReadLine());
                            figures.RemoveAt(num);
                            continue;
                        case 3:
                            foreach (Figure f in figures)
                            {
                                if (f is Triangle)
                                {
                                    Console.WriteLine("Traingle with area:" + f.GetArea());
                                }
                                else if (f is RectangularTriangle)
                                {
                                    Console.WriteLine("Rectangular triangle with area: " + f.GetArea());
                                }
                                else if (f is Quadrangle)
                                {
                                    Console.WriteLine("Quadrangle with area: " + f.GetArea());
                                }
                                else if (f is Circle)
                                {
                                    Console.WriteLine("Circle with area: " + f.GetArea());
                                }
                                else if (f is Square)
                                {
                                    Console.WriteLine("Square with area: " + f.GetArea());
                                }
                            }
                            continue;
                        case 4:
                            double area = 0;
                            foreach (Figure f in figures)
                            {
                                area += f.GetArea();
                                Console.WriteLine(f.GetArea());
                                Console.Write("Number of rectangular triangles:" + RectangularTriangle.Number_of_rect + "\nNumber of circles: " + Circle.GetNum +
                                    "\nNumber of quadrangles: " + Quadrangle.GetNum);
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
            Vertex[] Figurevertices = new Vertex[b];
            int index_of_comma = 0;
            for (int i = 0; i < b; i++) 
            {
                int old_index = index_of_comma;
                index_of_comma = coordinates.IndexOf(",", old_index+1);
                if (index_of_comma == -1)
                {
                    Figurevertices[i] = new Vertex(new double[] { double.Parse(coordinates[coordinates.Length - 2].ToString()), double.Parse(coordinates[coordinates.Length - 1].ToString()) });
                }
                else
                {
                    Figurevertices[i] = new Vertex(new double[] { double.Parse(coordinates[index_of_comma - 2].ToString()), double.Parse(coordinates[index_of_comma - 1].ToString()) });
                }
            }
            
            if (comma.Matches(coordinates).Count == 1)
            {
                return new Circle(Figurevertices);
            }
            else if (comma.Matches(coordinates).Count == 2)
            {
                return TriangleCreation(Figurevertices);
            }
            else
            {
                return new Quadrangle(Figurevertices);
            }
           
        }

        static Triangle TriangleCreation(Vertex[] vertices)
        {
            Triangle triangle = new Triangle(vertices);
            if (IsRectangle(triangle))
            {
                return new RectangularTriangle(vertices);
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
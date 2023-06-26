using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Points;

namespace Figures
{
    abstract class Figure
    {
        protected Color color;
        public Figure(Vertex[] vertices)
        {
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
            this.color = chosenColor;
        }
        public abstract double GetArea();
    }
    class Circle : Figure
    {
        private static int num_of_circles;
        private double radius;
        public Circle(Vertex[] vertices ) : base(vertices)  
        {   
            num_of_circles ++;
            radius = Math.Sqrt(Math.Pow(vertices[1].Pointcords[0] - vertices[0].Pointcords[0], 2) + Math.Pow(vertices[1].Pointcords[1] - vertices[0].Pointcords[1], 2));
            Console.WriteLine(radius.ToString());
        }
        public static string GetNum
        {
            get { return num_of_circles.ToString(); }
        }
        public override double GetArea()
        {
            return Math.Pow(radius, 2) * 3.14;
        }

    }
    class Quadrangle : Figure
    {
        private static int num_of_quadrangles;
        private Vertex[] vertices;
        private List<Double> sides;
        public Quadrangle(Vertex[] vertices ) : base(vertices) 
        {
            num_of_quadrangles++;
            this.vertices = vertices;
            this.sides = Sides();
        }
        public List<double> Sides()
        {
            List<double> sides = new List<double>();
            for (int i = 0; i < 4; i++)
            {
                //Доделать просчитывание площади было бы неплохо
                int j = (i + 1) % 4;
                sides.Add(Math.Sqrt(Math.Pow(this.vertices[j].Pointcords[0] - this.vertices[i].Pointcords[0], 2) + Math.Pow(this.vertices[j].Pointcords[1] - this.vertices[i].Pointcords[1], 2)));
            }
            return sides;
        }
        public static string GetNum 
        { 
                get { return num_of_quadrangles.ToString(); } 
        }
        public override double GetArea()
        {
            return sides[0] * sides[1];
        }
    }
    class Square : Quadrangle
    {
        private static int num_of_square = 0;
        
        public Square(Vertex[] vertices ) : base(vertices) 
        {
            num_of_square++;
        }
        new public static string GetNum
        {
            get { return num_of_square.ToString(); }
        }
    }
}

using Actions;
using Figures;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UI
{
    class UserInterface
    {
        
        private List<Figure> figures;
        private bool endProgram;
        public UserInterface(List<Figure> figures)
        {
            this.figures = figures;
            endProgram = false;
        }

        public bool EndProgram { get { return endProgram; } }
        //Пользователю даётся возможность выбирать из 4 возможных дейтсвий (Добавить фигуру, удалить фигуру, показать фигуры, общая площадь)
        public void ActionChoice()
        {
            Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area: ");
            Actions.Action action = new Actions.Action(figures);
            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Color lineColor = ColorChoice(true);
                        Color fillColor = ColorChoice(false);
                        figures.Add(action.FigureCreating(lineColor, fillColor));
                        break;
                    case 2:
                        action.DeletingFigure();
                        break;
                    case 3:
                        foreach (Figure f in figures)
                        {
                            Console.WriteLine(f.ToString() + " with area:" + f.GetArea().ToString());
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
        public Color ColorChoice(bool typeOfData)
        {
            if (typeOfData is true)
            {
                Console.WriteLine("Input figure line color: ");
            }
            else if (typeOfData is false)
            {
                Console.WriteLine("Input figure fill color: ");
            }
            try
            {
                Color chosenColor = Color.FromName(Console.ReadLine());
                return chosenColor;
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong color!");
                throw;
            }
        }
    }
}

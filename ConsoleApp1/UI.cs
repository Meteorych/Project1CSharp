using Actions;
using Figures;
using ListControl;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace UI
{
    class UserInterface
    {
        
        private FiguresList figuresList;
        private bool endProgram;
        public UserInterface(FiguresList figures)
        {
            this.figuresList = figures;
            endProgram = false;
        }

        public bool EndProgram { get { return endProgram; } }
        //Пользователю даётся возможность выбирать из 4 возможных дейтсвий (Добавить фигуру, удалить фигуру, показать фигуры, общая площадь)
        public void ActionChoice()
        {
            Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area: ");
            Actions.Action action = new Actions.Action(figuresList);
            try
            {
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Color lineColor = ColorChoice(true);
                        Color fillColor = ColorChoice(false);
                        figuresList.Insert(action.FigureCreating(lineColor, fillColor));
                        break;
                    case 2:
                        Console.WriteLine("Input the number of figure you want to delete: ");
                        int figureId = Convert.ToInt32(Console.ReadLine());
                        figuresList.Delete(figureId);
                        break;
                    case 3:
                        foreach (Figure f in figuresList.Figures)
                        {
                            Console.WriteLine(f.ToString() + " with area:" + f.GetArea().ToString());
                        }
                        break;
                    case 4:
                        Console.WriteLine("Total area:" + figuresList.GetTotalArea());
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

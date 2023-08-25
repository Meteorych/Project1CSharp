using Actions;
using ConsoleApp1.Figures;
using ConsoleApp1.RepositoryManage;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1.View
{
    class UserInterface
    {

        private FiguresList figuresList;
        private bool endProgram;
        public UserInterface(FiguresList figures, IRepository data)
        {
            figuresList = figures;
            RepositoryData = data;
            endProgram = false;
        }

        public bool EndProgram { get { return endProgram; } }
        //Пользователю даётся возможность выбирать из 4 возможных дейтсвий (Добавить фигуру, удалить фигуру, показать фигуры, общая площадь)
        public void ActionChoice()
        {
            while (endProgram == false)
            {
                Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, 4 -- Total Area:, 5 -- Save to Repository;");
                Actions.Action action = new Actions.Action(figuresList);
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Color lineColor = ColorChoice(true);
                            Color fillColor = ColorChoice(false);
                            figuresList.Add(action.FigureCreating(lineColor, fillColor));
                            break;
                        case 2:
                            Console.WriteLine("Input the number of figure you want to delete: ");
                            int figureId = Convert.ToInt32(Console.ReadLine());
                            figuresList.Remove(figureId);
                            break;
                        case 3:
                            if (figuresList.Figures != null)
                            {
                                foreach (Figure f in figuresList.Figures)
                                {
                                    Console.WriteLine(f.ToString() + " with area:" + f.GetArea().ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("List of figures is empty!");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Total area:" + figuresList.GetTotalArea());
                            break;
                        case 5:
                            figuresList.Save(RepositoryData);
                            break;
                        default:
                            endProgram = true;
                            RepositoryData.Dump();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong Symbol!");
                }
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

        public IRepository RepositoryData { get; set; }
    }
}

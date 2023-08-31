using ConsoleApp1.Actions;
using ConsoleApp1.Figures;
using ConsoleApp1.RepositoryManage;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleApp1.View
{
    class UserInterfaceConsole : UserInterface
    {

        public UserInterfaceConsole(FiguresManager figures, IRepository data, Dictionary<string, string> keyPhrases) 
            : base(figures, data, keyPhrases)
        {
        }

        /// <summary>
        /// The user is given the choice between 5 options (Add figure, delete figure, show figure, total area of figures, save to repository)
        /// </summary>
        public override void ActionChoice()
        {
            while (_endProgram == false)
            {
                Console.WriteLine("Choose operations: 1 -- Add Figure, 2 -- Delete Figure, 3 -- Show figures, " +
                    "4 -- Total Area:, 5 -- Save to Repository;");
                Actions.Action action = new();
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Color lineColor = ColorChoice(true);
                            Color fillColor = ColorChoice(false);
                            _figuresList.Add(action.FigureCreating(lineColor, fillColor));
                            break;
                        case 2:
                            Console.WriteLine("Input the number of figure you want to delete: ");
                            int figureId = Convert.ToInt32(Console.ReadLine());
                            _figuresList.Remove(figureId);
                            break;
                        case 3:
                            if (_figuresList.Figures != null)
                            {
                                foreach (Figure f in _figuresList.Figures)
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
                            Console.WriteLine("Total area:" + _figuresList.GetTotalArea());
                            break;
                        case 5:
                            RepositoryData = _figuresList.Save(RepositoryData);
                            break;
                        default:
                            _endProgram = true;
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
        /// <summary>
        /// Choice of line or fill color for figure
        /// </summary>
        /// <param name="typeOfData"></param>
        /// <returns>Chosen color</returns>
        public override Color ColorChoice(bool typeOfData)
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
                string? colorName = null;
                do
                {
                    colorName = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(colorName));

                Color chosenColor = Color.FromName(colorName);
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

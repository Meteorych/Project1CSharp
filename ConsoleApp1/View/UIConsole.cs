using ConsoleApp1.Actions;
using ConsoleApp1.Figures;
using ConsoleApp1.RepositoryManage;
using System.Drawing;
using System.Text.RegularExpressions;

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
        /// <exception name = "FormatException">Exception is called when you type wrong symbol into console</exception>
        /// </summary>
        public override void ActionChoice()
        {
            while (_endProgram == false)
            {
                Console.WriteLine(_keyPhrases["MainChoice"]);
                Actions.Action action = new();
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Color lineColor = ColorChoice(true);
                            Color fillColor = ColorChoice(false);
                            _figuresList.Add(action.FigureCreating(lineColor, fillColor, CoordinatesInput()));
                            break;
                        case 2:
                            Console.WriteLine(_keyPhrases["DeleteFigure"]);
                            int figureId = Convert.ToInt32(Console.ReadLine());
                            _figuresList.Remove(figureId);
                            break;
                        case 3:
                            if (_figuresList.Figures != null)
                            {
                                foreach (var f in _figuresList.Figures)
                                {
                                    Console.WriteLine(f.ToString() + _keyPhrases["WithArea"] + f.GetArea().ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            if (_figuresList.GetTotalArea() != 0)
                            {
                                Console.WriteLine(_keyPhrases["TotalArea"] + _figuresList.GetTotalArea());
                            }
                            else
                            {
                                Console.WriteLine(_keyPhrases["EmptyFigureList"]);
                            }
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
                    Console.WriteLine(_keyPhrases["WrongSymbol"]);
                }
            }
        }
        /// <summary>
        /// Input of coordinates for some figure
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public override string CoordinatesInput()
        {

            Console.WriteLine(_keyPhrases["CoordinatesInputPhrase"]);
            string? coordinates;
            do
            {
                coordinates = Console.ReadLine();
            } while (string.IsNullOrEmpty(coordinates));

            Regex regex = new(@"[^0-9,]");
            if (regex.Matches(coordinates).Count != 0 || coordinates.Length == 0 || coordinates.Length == 1)
            {
                throw new FormatException(_keyPhrases["FormatExceptionPhrase"]);
            }
            else
            {
                return coordinates;
            }
        }
        /// <summary>
        /// Choice of line or fill color for figure
        /// </summary>
        /// <param name="typeOfData">Выбор какой тип даты вы хотите получить</param>
        /// <returns>Chosen color</returns>
        public override Color ColorChoice(bool typeOfData)
        {
            if (typeOfData)
            {
                Console.WriteLine(_keyPhrases["LineColor"]);
            }
            else if (typeOfData is false)
            {
                Console.WriteLine(_keyPhrases["FillColor"]);
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
                Console.WriteLine(_keyPhrases["WrongColor"]);
                throw;
            }
        }

    }
}

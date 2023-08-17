using Figures;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using ConsoleApp1.View;
using ConsoleApp1.Figures;

namespace Program
{

    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            //Разобраться с односительным путем
            //Передавать через интерфейсы
            //Сделать отдельный класс-репозиторий, реализовать так же UI
            string fileName = "FiguresData.json";
            FiguresList figures = new FiguresList(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName)));
            UserInterface userInterface = new UserInterface(figures);
            //Перенести всю работу с пользователм UI
            while (true)
            {
                userInterface.ActionChoice();
                if (userInterface.EndProgram == true)
                {
                    string jsonString = JsonSerializer.Serialize(figures, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText((Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName)), jsonString);
                    break;
                }
            }

        } 
    }
 }
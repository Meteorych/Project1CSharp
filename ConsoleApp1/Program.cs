using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using ConsoleApp1.View;
using ConsoleApp1.Figures;
using IRepositoryJson;

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
            string extension = Path.GetExtension(fileName);
            if (extension == "json")
            {
                IRepositoryJson.IRepositoryJson repositoryData = new IRepositoryJson.IRepositoryJson();
                repositoryData.Upload(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName));
                FiguresList figureslist = repositoryData.GetData;
            }
            else
            {
                IRepositoryJson.IRepositoryJson repositoryData = new IRepositoryJson.IRepositoryJson();
                FiguresList figureslist = repositoryData.FiguresList;
            }
    
            
            UserInterface userInterface = new UserInterface(figureslist);
            //Перенести всю работу с пользователм UI
            while (true)
            {
                userInterface.ActionChoice();
                if (userInterface.EndProgram == true)
                {
                    
                    re
                    break;
                }
            }

        } 
    }
 }
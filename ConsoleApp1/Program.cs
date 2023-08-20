using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using ConsoleApp1.View;
using ConsoleApp1.Figures;
using IRepositoryJson;
using IRepository;
using RepositoryFactory;

namespace Program
{

    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            //Сделать отдельный класс-репозиторий, реализовать так же UI
            string fileName = "FiguresData.json";
            RepositoryFactory.RepositoryFactory repositoryChoice = new RepositoryFactory.RepositoryFactory(fileName);
            IRepository.IRepository repositoryData = repositoryChoice.RepositoryData;
            FiguresList figures = new FiguresList();
            figures.Figures = repositoryData.GetData;
            UserInterface userInterface = new UserInterface(figures);
            //Перенести всю работу с пользователм UI
            while (true)
            {
                userInterface.ActionChoice();
                if (userInterface.EndProgram == true)
                {
                    repositoryData.Dump();
                    break;
                }
            }

        } 
    }
 }
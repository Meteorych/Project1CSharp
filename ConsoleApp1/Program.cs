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
            string fileName = "FiguresData.json";
            RepositoryFactory.RepositoryFactory repositoryChoice = new RepositoryFactory.RepositoryFactory(fileName);
            IRepository.IRepository repositoryData = repositoryChoice.RepositoryData;
            FiguresList figures = new FiguresList();
            if (repositoryData.Data != null) 
            {
                figures.Figures = repositoryData.Data;
            }
            UserInterface userInterface = new UserInterface(figures);
            userInterface.ActionChoice();
            repositoryData.Dump();
                    
            

        } 
    }
 }
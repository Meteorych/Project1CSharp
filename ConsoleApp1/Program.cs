using ConsoleApp1.View;
using ConsoleApp1.Figures;
using ConsoleApp1.RepositoryManage;
using ConsoleApp1.DataAccessLayer;

namespace Program
{

    class Program
    {
        static void Main()
        {
            string fileName = "FiguresData.json";
            IRepository repositoryData = new RepositoryFactory(fileName).RepositoryData;
            FiguresList figures = new FiguresList();
            figures.Figures = new DALParser().CreateIsntance(repositoryData.Data);
            new UserInterface(figures, repositoryData).ActionChoice();
        } 
    }
 }
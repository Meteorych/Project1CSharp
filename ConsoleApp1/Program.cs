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
            Dictionary<string, string> keyPhrases = new KeyPhrasesParser().KeyPhrases;
            IRepository repositoryData = new RepositoryFactory(fileName).RepositoryData;
            FiguresManager figures = new()
            {
                Figures = DALParser.CreateIsntance(repositoryData.Data)
            };
            //Весь хардкод в константы, хранящие0ся в словарике
            new UserInterfaceConsole(figures, repositoryData, keyPhrases).ActionChoice();
        } 
    }
 }
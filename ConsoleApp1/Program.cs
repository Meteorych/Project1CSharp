using Figures;
using UI;
using JSON;
using System.Text.Json;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            string jsonData = File.ReadAllText("FiguresData.json");
            List<Figure> figures = new List<Figure>();
            if (jsonData.Length > 0)
            {
                figures = JsonSerializer.Deserialize<List<Figure>>(jsonData);
            }
            UserInterface userInterface = new UserInterface(figures);
            while (true)
            {
                userInterface.ActionChoice();
                if (userInterface.EndProgram == true)
                {
                    break;
                }
            }

        } 
    }
 }
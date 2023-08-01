using Figures;
using UI;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            string jsonData = File.ReadAllText("C:/CSharp and DotNet/Project1/ConsoleApp1/FiguresData.json");
            List<Figure> figures = new List<Figure>();
            if (jsonData.Length > 0)
            {
                figures = JsonSerializer.Deserialize<List<Figure>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true });
            }
            UserInterface userInterface = new UserInterface(figures);
            while (true)
            {
                userInterface.ActionChoice();
                if (userInterface.EndProgram == true)
                {
                    string jsonString = JsonSerializer.Serialize(figures, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("C:/CSharp and DotNet/Project1/ConsoleApp1/FiguresData.json", jsonString);
                    break;
                }
            }

        } 
    }
 }
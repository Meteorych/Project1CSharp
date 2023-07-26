using Figures;
using UI;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            List<Figure> figures = new List<Figure>();
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
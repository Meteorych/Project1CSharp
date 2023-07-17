using System.Drawing;
using Triangles;
using Figures;
using Circles;
using Actions;
using Points;
using Qudrangles;

namespace Program {
    
    class Program
    {
        static void Main()
        {
            //Stopwatch stopwatch = new Stopwatch();
            List<Figure> figures = new List<Figure>();
            Actions.Action userInterface = new Actions.Action(figures);
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
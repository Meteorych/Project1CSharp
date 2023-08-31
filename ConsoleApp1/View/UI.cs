using ConsoleApp1.Figures;
using ConsoleApp1.RepositoryManage;
using System.Drawing;

namespace ConsoleApp1.View
{
    abstract class UserInterface
    {
        private protected FiguresManager _figuresList;
        private protected bool _endProgram;
        private protected Dictionary<string, string> _keyPhrases;

        public UserInterface(FiguresManager figures, IRepository data, Dictionary<string, string> keyPhrases)
        {
            _figuresList = figures;
            RepositoryData = data;
            _endProgram = false;
            _keyPhrases = keyPhrases;
        }
        public IRepository RepositoryData { get; set; }
        public abstract void ActionChoice();
        public abstract Color ColorChoice(bool typeOfData);
        public bool EndProgram { get { return _endProgram; } }
    }
}

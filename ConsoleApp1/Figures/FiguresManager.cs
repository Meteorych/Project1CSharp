using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using ConsoleApp1.RepositoryManage;
using ConsoleApp1.DataAccessLayer;

namespace ConsoleApp1.Figures
{
    
    class FiguresManager
    {
        private List<Figure> _figures;
        //при реализации каждого шага по выбору пользователя сохранять в репозитории
        public FiguresManager()
        {
            _figures = new List<Figure>();
        }
        public IRepository Save(IRepository data)
        {
            data.Data = DALParser.FromIsntanceToDAL(_figures);
            return data;
        }
        public void Add(Figure figure)
        {
            _figures.Add(figure);
        }
        public void Remove(int figureId)
        {
            _figures.RemoveAt(figureId);
        }
        public double GetTotalArea()
        {
            double area = 0;
            foreach (Figure f in _figures)
            {
                area += f.GetArea();
            }
            return area;
        }
        public List<Figure> Figures { get { return _figures; } set { _figures = value; } }
    }
}

using IRepository;
using System.Text.Json.Serialization;
using System.Text.Json;
using UI;
using System;

namespace ConsoleApp1.Figures
{
    class FiguresList
    {
        List<Figure> figures = new List<Figure>();
        //при реализации каждого шага по выбору пользователя сохранять в репозитории
        public FiguresList(string jsonData)
        {
            List<Figure> figures = new List<Figure>();

        }

        public void Save(Figure figure)
        {
            figures.Add(figure);
        }
        public void Dump(int figureId)
        {
            figures.RemoveAt(figureId);
        }
        public double GetTotalArea()
        {
            double area = 0;
            foreach (Figure f in figures)
            {
                area += f.GetArea();
            }
            return area;
        }
        public List<Figure> Figures { get { return figures; } }
    }
}

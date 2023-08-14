using IRepository;
using Figures;
using System.Text.Json.Serialization;
using System.Text.Json;
using UI;
using System;

namespace ListControl
{
    class FiguresList : IRepositoryJson
    {
        List<Figure> figures = new List<Figure>();
        //при реализации каждого шага по выбору пользователя сохранять в репозитории
        public FiguresList(string jsonData)
        {
            List<Figure> figures = new List<Figure>();
            if (jsonData.Length > 0)
            {
                figures = JsonSerializer.Deserialize<List<Figure>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public void Insert(Figure figure)
        {
            figures.Add(figure);
        }
        public void Delete(int figureId)
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

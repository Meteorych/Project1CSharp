using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using ConsoleApp1.RepositoryManage;
using ConsoleApp1.DataAccessLayer;

namespace ConsoleApp1.Figures
{
    /// <summary>
    /// Class for work with list of figures.
    /// </summary>
    class FiguresManager
    {
        private List<Figure> _figures;
            
        public FiguresManager()
        {
            _figures = new List<Figure>();
        }
        /// <summary>
        /// Method for saving figures into repository.
        /// </summary>
        /// <param name="data">Usable repository</param>
        /// <returns>Repository with new data</returns>
        public IRepository Save(IRepository data)
        {
            data.Data = DALParser.FromInstanceToDal(_figures);
            return data;
        }
        /// <summary>
        /// Add figure to the list.
        /// </summary>
        /// <param name="figure">New Figure object to add</param>
        public void Add(Figure figure)
        {
            _figures.Add(figure);
        }
        /// <summary>
        /// Remove figure from list.
        /// </summary>
        /// <param name="figureId">Position of deleted figure in the list</param>
        public void Remove(int figureId)
        {
            _figures.RemoveAt(figureId);
        }
        /// <summary>
        /// Returning total area of figures in the list.
        /// </summary>
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

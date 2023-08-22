﻿using IRepository;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace ConsoleApp1.Figures
{
    class FiguresList
    {
        private List<Figure> figures;
        //при реализации каждого шага по выбору пользователя сохранять в репозитории
        public FiguresList()
        {
            figures = new List<Figure>();
        }
        public void Save()
        {
            
        }
        public void Add(Figure figure)
        {
            figures.Add(figure);
        }
        public void Remove(int figureId)
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
        public List<Figure> Figures { get { return figures; } set { figures = value; } }
    }
}
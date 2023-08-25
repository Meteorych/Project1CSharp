using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Figures;
using ConsoleApp1.DataAccessLayer;

namespace ConsoleApp1.RepositoryManage
{
    class IRepositoryJson : IRepository
    {
        private string? repositoryData;
        private string fileName;
        private List<FigureJSON> figures;
        void IRepository.Upload(string fileName)
        {
            this.fileName = fileName;
            repositoryData = File.ReadAllText(fileName);
            figures = new List<FigureJSON>();
            if (repositoryData != null)
            {
                figures = JsonSerializer.Deserialize<List<FigureJSON>>(repositoryData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
        void IRepository.Dump()
        {
            string RepositoryData = JsonSerializer.Serialize(figures, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName), RepositoryData);
        }
        public List<Figure> Data()
        {

        }
    }
}

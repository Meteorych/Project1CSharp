using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using ConsoleApp1.Figures;

namespace IRepositoryJson
{
    class IRepositoryJson : IRepository.IRepository
    {
        private string? repositoryData;
        private string fileName;
        private List<Figure> figures;
        public void Upload(string fileName) 
        {
            this.fileName = fileName;
            repositoryData = File.ReadAllText(fileName);
            figures = new List<Figure>();
            if (repositoryData != null) 
            { 
                figures = JsonSerializer.Deserialize<List<Figure>>(repositoryData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ;
            }
        }
        public void Dump()
        {
            string RepositoryData = JsonSerializer.Serialize(figures, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText((Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName)), RepositoryData);
        }
        public List<Figure> GetData
        { get { return figures; } }
    }
}

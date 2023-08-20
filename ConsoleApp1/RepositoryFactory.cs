using ConsoleApp1.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    class RepositoryFactory
    {
        private IRepository.IRepository repositoryData;
        public RepositoryFactory(string fileName) {
            string extension = Path.GetExtension(fileName);
            FiguresList figuresList = new FiguresList();
            if (extension == "json")
            {
                repositoryData = new IRepositoryJson.IRepositoryJson();
                repositoryData.Upload(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName));
                
            }
            else
            {
                repositoryData = new IRepositoryJson.IRepositoryJson();
                figuresList.Figures = repositoryData.GetData;
            }
        }

        public IRepository.IRepository RepositoryData { get { return repositoryData; }}
    }
}

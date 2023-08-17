using Figures;
namespace IRepository
{
    interface IRepository
    {
        void Save(string fileName);
        void Dump(string repositoryData);
    }
}

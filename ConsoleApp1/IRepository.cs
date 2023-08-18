using ConsoleApp1.Figures;
namespace IRepository
{
    interface IRepository
    {
        void Upload(string fileName);
        void Dump(string repositoryData);
    }
}

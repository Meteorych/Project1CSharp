using ConsoleApp1.DataAccessLayer;

namespace ConsoleApp1.RepositoryManage
{
    interface IRepository
    {
        void Upload(string fileName);
        void Dump();
        List<FigureJSON> Data { get; set; }
    }
}

using ConsoleApp1.DataAccessLayer;
//реализовать суперкласс
namespace ConsoleApp1.RepositoryManage
{
    interface IRepository
    {
        void Upload(string fileName);
        void Dump();
        List<FigureJSON> Data { get; set; }
    }
}

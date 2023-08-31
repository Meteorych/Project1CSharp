namespace ConsoleApp1.RepositoryManage
{
    class RepositoryFactory
    {
        private IRepository repositoryData;
        public RepositoryFactory(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == ".json")
            {
                repositoryData = new IRepositoryJson();
                repositoryData.Upload(Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\", fileName));

            }
            else
            {
                repositoryData = new IRepositoryJson();
            }
        }

        public IRepository RepositoryData { get { return repositoryData; } }
    }
}

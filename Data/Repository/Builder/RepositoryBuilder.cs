using Auto.Interfaces;

namespace Data.Repository.Builder
{
    
    public class RepositoryBuilder<T> : IRepositoryBuilder<T> where T : class
    {
        public FileBasedRepositoryBuilder<T> FileBased()
        {
            return new FileBasedRepositoryBuilder<T>();
        }

        public SqlRepositoryBuilder<T> Sql()
        {
            return new SqlRepositoryBuilder<T>();
        }

        public IRepository<T> Build()
        {
            throw new InvalidOperationException();
        }
    }
}

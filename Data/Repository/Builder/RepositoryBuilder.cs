namespace Data.Repository.Builder
{

    public class RepositoryBuilder<T> where T : class
    {
        public FileBasedRepositoryBuilder<T> FileBased()
        {
            return new FileBasedRepositoryBuilder<T>();
        }
    }
}

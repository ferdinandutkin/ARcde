using Auto.Interfaces;
using Data.Sql;

namespace Data.Repository.Builder;

public class SqlRepositoryBuilder<T> : IRepositoryBuilder<T> where T : class
{
    private string? _baseName;
    public SqlRepositoryBuilder<T> WithName(string name)
    {
        _baseName = name;
        return this;
    }

    public IRepository<T> Build()
        => new EFRepository<T>(new ApplicationContext(_baseName));

}
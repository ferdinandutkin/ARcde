using Auto.Interfaces;

namespace Data.Repository.Builder;

public interface IRepositoryBuilder<T> : IBuilder<IRepository<T>>
{

}
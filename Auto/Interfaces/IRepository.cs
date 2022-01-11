namespace Auto.Interfaces;

public interface IRepository<T>
{
    T Add(T value);
    IEnumerable<T> All();
    void Delete(T t);
    T Update(T value);
}

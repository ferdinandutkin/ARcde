namespace Auto.Interfaces;

public interface IRepository<T>
{
    T Add(T value);
    IEnumerable<T> All();
    void Remove(T value);
    T Update(T value);
}

namespace Auto.Interfaces;

public interface IFactory<TArgs, TResult>
{
    TResult? CreateInstance(TArgs officeName);
}

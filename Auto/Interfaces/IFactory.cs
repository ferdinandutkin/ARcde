namespace Auto.Interfaces;

internal interface IFactory<TArgs, TResult>
{
    TResult? CreateInstance(TArgs args);
}

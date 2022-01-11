namespace Data.Serialization;

public interface ISerializer
{
    string Serialize(object value);
    object Deserialize(string text);
}
public interface ISerializer<T> : ISerializer
{
    string Serialize(T value);
    new T Deserialize(string text);
}

 
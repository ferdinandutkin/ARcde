namespace Data.Serialization;

public interface ISerializer<T>
{
    string Serialize(T value);
    T Deserialize(string text);
}

 
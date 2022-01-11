namespace Data.Serialization;

public  abstract class SerializerBase<T> : ISerializer<T>
{
    public abstract T Deserialize(string text);

    public abstract string Serialize(T value);

    public string Serialize(object value)
        => Serialize((T)value);
  
    object ISerializer.Deserialize(string text)
        => Deserialize(text);
      
}
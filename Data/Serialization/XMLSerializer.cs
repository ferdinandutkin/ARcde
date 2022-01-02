namespace Data.Serialization;

public class XmlSerializer<T> : ISerializer<T>
{
    protected static readonly System.Xml.Serialization.XmlSerializer Serializer = new(typeof(T));
    public virtual string Serialize(T value)
    {
        using var stringWriter = new StringWriter();
        Serializer.Serialize(stringWriter, value);
        return stringWriter.ToString();
    }

    public virtual T Deserialize(string text)
    {
        using var stringReader = new StringReader(text);
        return (T)Serializer.Deserialize(stringReader);
    }
}
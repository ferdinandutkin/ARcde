namespace Data.Serialization.Xml;

public class XmlSerializer<T> : SerializerBase<T>
{
    protected static readonly System.Xml.Serialization.XmlSerializer Serializer = new(typeof(T));
    public override string Serialize(T value)
    {
        using var stringWriter = new StringWriter();
        Serializer.Serialize(stringWriter, value);
        return stringWriter.ToString();
    }

    public override T Deserialize(string text)
    {
        using var stringReader = new StringReader(text);
        return (T)Serializer.Deserialize(stringReader);
    }
}
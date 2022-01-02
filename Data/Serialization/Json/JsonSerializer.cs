namespace Data.Serialization.Json;

public class JsonSerializer<T> : ISerializer<T>
{
    protected readonly System.Text.Json.JsonSerializerOptions Options;
    
    public JsonSerializer(System.Text.Json.JsonSerializerOptions options)
    {
        Options = options;
    }
    public virtual string Serialize(T value) => System.Text.Json.JsonSerializer.Serialize(value, Options);

    public virtual T Deserialize(string text) => System.Text.Json.JsonSerializer.Deserialize<T>(text, Options);

}
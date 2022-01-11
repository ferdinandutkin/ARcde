using System.Text.Json;

namespace Data.Serialization.Json;

public class JsonSerializer<T> : SerializerBase<T>
{
    protected readonly JsonSerializerOptions Options;
    
    public JsonSerializer(JsonSerializerOptions options)
    {
        Options = options;
    }

    public JsonSerializer()
    {
        Options = new JsonSerializerOptions();
    }
    public override string Serialize(T value) => JsonSerializer.Serialize(value, Options);

    public override T Deserialize(string text) => System.Text.Json.JsonSerializer.Deserialize<T>(text, Options);

}
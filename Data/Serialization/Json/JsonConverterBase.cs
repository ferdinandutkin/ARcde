using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Serialization.Json;

internal abstract class JsonConverterBase<T> : JsonConverter<T>
{
    protected static string ToPropertyNameCase(string propertyName, JsonSerializerOptions options)
        => options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName;
}

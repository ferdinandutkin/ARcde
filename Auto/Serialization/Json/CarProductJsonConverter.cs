using System.Text.Json;
using Auto.Product;

namespace Auto.Serialization.Json;

internal class CarProductJsonConverter : JsonConverterBase<CarProduct>
{
    public override CarProduct? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var pricePropertyName = ToPropertyNameCase(nameof(CarProduct.Price), options);

        var countPropertyName = ToPropertyNameCase(nameof(CarProduct.Count), options);

        var namePropertyName = ToPropertyNameCase(nameof(CarProduct.Name), options);

        var subjectPropertyName = ToPropertyNameCase(nameof(CarProduct.Subject), options);


        var price = 0;

        var count = 0;

        string name = null;

        Car subject = null;

        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();


        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject) return new CarProduct(subject, price, count);

            if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

            var propertyName = reader.GetString();

            reader.Read();

            if (propertyName == pricePropertyName)
                price = reader.GetInt32();
            else if (propertyName == countPropertyName)
                count = reader.GetInt32();
            else if (propertyName == subjectPropertyName)
                subject = JsonSerializer.Deserialize<Car>(ref reader, options);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, CarProduct value, JsonSerializerOptions options)
    {
        var pricePropertyName = ToPropertyNameCase(nameof(CarProduct.Price), options);

        var countPropertyName = ToPropertyNameCase(nameof(CarProduct.Count), options);

        var namePropertyName = ToPropertyNameCase(nameof(CarProduct.Name), options);

        var subjectPropertyName = ToPropertyNameCase(nameof(CarProduct.Subject), options);

        writer.WriteStartObject();

        writer.WriteString(namePropertyName, value.Name);

        writer.WriteNumber(pricePropertyName, value.Price);

        writer.WriteNumber(countPropertyName, value.Count);

        writer.WritePropertyName(subjectPropertyName);
        JsonSerializer.Serialize(writer, value.Subject, options);

        writer.WriteEndObject();
    }
}
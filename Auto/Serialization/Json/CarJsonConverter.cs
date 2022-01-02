using System.Text.Json;
using Auto.Product;

namespace Auto.Serialization.Json;

internal class CarJsonConverter : JsonConverterBase<Car>
{
    public override Car? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string markPropertyName = ToPropertyNameCase(nameof(Car.Mark), options);

        string modelPropertyName = ToPropertyNameCase(nameof(Car.Model), options);

        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        string mark = null;

        string model = null;


        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return new Car(mark, model);
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string propertyName = reader.GetString();
            reader.Read();


            if (propertyName == markPropertyName)
                mark = reader.GetString();
            else if (propertyName == modelPropertyName)
                model = reader.GetString();

        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Car value, JsonSerializerOptions options)
    {

        string markPropertyName = ToPropertyNameCase(nameof(Car.Mark), options);

        string modelPropertyName = ToPropertyNameCase(nameof(Car.Model), options);

        writer.WriteStartObject();

        writer.WriteString(modelPropertyName, value.Model);

        writer.WriteString(markPropertyName, value.Mark);

        writer.WriteEndObject();
    }
}

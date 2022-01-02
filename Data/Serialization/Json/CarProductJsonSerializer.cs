using System.Text.Json;
using Auto.Product;

namespace Data.Serialization.Json
{
    internal class CarProductJsonSerializer : JsonSerializer<CarProduct[]>
    {
        private static readonly JsonSerializerOptions options = new() { Converters = { new CarProductJsonConverter(), new CarJsonConverter() } };
        public CarProductJsonSerializer() : base(options)
        {
        }
    }
}

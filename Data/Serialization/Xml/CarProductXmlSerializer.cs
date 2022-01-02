using Auto.Product;
using AutoMapper;

namespace Data.Serialization.Xml;

public class CarProductXmlSerializer : XmlSerializer<CarProduct[]>
{

    private static readonly MapperConfiguration _config = new(cfg =>
    {
        cfg.CreateMap<XMLCarProduct.XMLCar, Car>();
        cfg.CreateMap<Car, XMLCarProduct.XMLCar>();
        cfg.CreateMap<XMLCarProduct, CarProduct>();
        cfg.CreateMap<CarProduct, XMLCarProduct>();
    });

    private static readonly IMapper _mapper = _config.CreateMapper();

    private static readonly XmlSerializer<XMLCarProduct[]> _serializer = new();
    public class XMLCarProduct
    {
        public int Price { get; set; }
        public int Count { get; set; }

        public class XMLCar
        {
            public string Mark { get; set; }
            public string Model { get; set; }

        }
        public XMLCar Subject { get; set; }
    }

    public override string Serialize(CarProduct[] value)
    {
        var xmlCarProducts = _mapper.Map<XMLCarProduct[]>(value);
        return _serializer.Serialize(xmlCarProducts);
    }

    public override CarProduct[] Deserialize(string text)
    {
        var deserialized = _serializer.Deserialize(text);
        return _mapper.Map<CarProduct[]>(deserialized);
    }
}


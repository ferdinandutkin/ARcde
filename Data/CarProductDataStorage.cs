using Auto.Interfaces;

namespace Data;

public class CarProductDataStorage : IEntity
{
    public int Id { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }

    public class CarDataStorage : IEntity
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }

    }
    public CarDataStorage Subject { get; set; }
}

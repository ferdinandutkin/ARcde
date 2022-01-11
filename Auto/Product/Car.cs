using Auto.Interfaces;

namespace Auto.Product;

public class Car : IEntity
{
    public int Id { get; set; }

    public readonly string Mark;

    public readonly string Model;

    public Car(string mark, string model)
    {
        Mark = mark;
        Model = model;
    }
}

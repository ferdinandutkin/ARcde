namespace Auto.Product;

public class CarProduct : Product<Car>
{
    public CarProduct(Car car, int price, int count) : base(car)
    {
        Price = price;
        Count = count;
    }

    public override string Name => $"{Subject.Mark} {Subject.Model}";
}

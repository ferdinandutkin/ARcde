using Auto.Product;

public class AdminViewModel
{
    public AdminViewModel(CarProduct[] carProducts)
    {
        Products = carProducts;
    }

    public CarProduct[] Products { get; }
}
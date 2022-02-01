using Auto.Product;
using Web.Models;

namespace Web.ViewModels;

public class IndexViewModel
{
    public CarProduct[] Products { get; }
    public BuyFormViewModel BuyFormViewModel { get; }
    public SellFormModel SellFormViewModel { get; }
    public IndexViewModel(CarProduct[] products)
    {
        Products = products;
        BuyFormViewModel = new (products);
        SellFormViewModel = new (products);
    }
}
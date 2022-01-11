using Auto.Product;

namespace Web.Models
{
    public class IndexModel
    {
        public CarProduct[] Products { get; }
        public BuyFormModel BuyFormModel { get; }
        public SellFormModel SellFormModel { get; }
        public IndexModel(CarProduct[] products)
        {
            Products = products;
            BuyFormModel = new (products);
            SellFormModel = new (products);
        }
    }
}

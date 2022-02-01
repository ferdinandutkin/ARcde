using Auto.Product;

namespace Web.Models
{
    public class SellFormModel
    {
        public IReadOnlyCollection<string> Marks { get; }

        public IReadOnlyCollection<string> Models { get; }

        public SellFormModel(IReadOnlyCollection<CarProduct> carProducts)
        {
          
            Marks = carProducts.Select(carProduct => carProduct.Subject.Mark).Distinct().ToArray();

            Models = carProducts.Select(carProduct => carProduct.Subject.Model).Distinct().ToArray();

        }
    }
}

using Auto.Product;

namespace Web.ViewModels
{
    public class BuyFormViewModel
    {

        public IReadOnlyCollection<string> Marks { get; }

        public IReadOnlyCollection<string> Models { get; }

        public int MaxCount { get; }
        public BuyFormViewModel(IReadOnlyCollection<CarProduct> carProducts)
        {

            Marks = carProducts.Select(carProduct => carProduct.Subject.Mark).Distinct().ToArray();

            Models = carProducts.Select(carProduct => carProduct.Subject.Model).Distinct().ToArray();

            MaxCount = carProducts.Any() ? carProducts.Max(carProduct => carProduct.Count) : 0;
        }
    }
}

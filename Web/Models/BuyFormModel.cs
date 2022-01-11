using Auto.Product;

namespace Web.Models
{
    public class BuyFormModel
    {
        public IReadOnlyDictionary<string, string[]> MarkModelsDictionary { get; }

        public IReadOnlyCollection<string> Marks { get; }

        public IReadOnlyCollection<string> Models { get; }

        public int MaxCount { get; }
        public BuyFormModel(IReadOnlyCollection<CarProduct> carProducts)
        {
            MarkModelsDictionary = carProducts.ToLookup(product => product.Subject.Mark, product => product.Subject.Model)
                .ToDictionary(product => product.Key, product => product.ToArray());

            Marks = carProducts.Select(carProduct => carProduct.Subject.Mark).Distinct().ToArray();

            Models = carProducts.Select(carProduct => carProduct.Subject.Model).Distinct().ToArray();

            MaxCount = carProducts.Max(carProduct => carProduct.Count);
        }
    }
}

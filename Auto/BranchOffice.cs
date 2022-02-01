using Auto.Interfaces;
using Auto.Product;

namespace Auto;


 
internal class BranchOffice 
{
    public string Mark { get; set; }

    public List<CarProduct> Products { get; private set; }


    private readonly IRepository<CarProduct> _repository;

    public BranchOffice(string mark, IRepository<CarProduct> repository)
    {

        _repository = repository;
        Mark = mark;
        Products = new(_repository.All());
    
    }

    internal void Buy(string model, int count)
    {
        var product = Products.FirstOrDefault(product => product.Subject.Model == model) ?? throw new ArgumentException($"Unknown model: \"{model}\"");

        product.Count += count;

        _repository.Update(product);
    }

    internal void Add(string model, int count, int price)
    {
        var product = new CarProduct(new Car(Mark, model), price, count);
        Products.Add(product);

        _repository.Add(product);
    }

    internal void Remove(string model)
    {
        var product = Products.FirstOrDefault(product => product.Subject.Model == model) ?? throw new ArgumentException($"Unknown model: \"{model}\"");

        Products.Remove(product);

        _repository.Remove(product);
    }

    internal void Sell(string model, int count)
    {
        var product = Products.FirstOrDefault(product => product.Subject.Model == model) ?? throw new ArgumentException(nameof(model));

        if (product.Count >= count)
        {
            product.Count -= count;
            _repository.Update(product);
            return;
        }
        throw new ArgumentOutOfRangeException($"not possible to sell {count} of {model}; only {product.Count} in stock");
    }
}

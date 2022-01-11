namespace Auto.Product;

public abstract class Product<T>
{
    public int Id { get; set; }
    public Product(T subject) => Subject = subject;

    public virtual int Price { get; set; }
    public virtual int Count { get; set; }
    public abstract string Name { get; }

    public T Subject { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Product<T> product &&
               Name == product.Name &&
               EqualityComparer<T>.Default.Equals(Subject, product.Subject);
    }

    public override string ToString() => $"Name: {Name}, Count: {Count}, Price: {Price}";
}

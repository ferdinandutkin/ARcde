using Auto.Product;

namespace Auto.IO;

public interface IIOProvider
{
    void Write(CarProduct[] cars);
    string ReadString();
    void Write(string @string);
}

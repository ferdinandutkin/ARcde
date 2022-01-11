using Auto.IO;
using Auto.Product;

namespace Console.IO;
public class ConsoleIOProvider : IIOProvider
{

    public void Write(CarProduct[] cars) => Write(string.Join(Environment.NewLine, cars.Select(car => car.ToString())));

    public string ReadString() => System.Console.ReadLine() ?? string.Empty;

    public void Write(string @string) => System.Console.WriteLine(@string);

}


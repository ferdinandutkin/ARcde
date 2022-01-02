namespace Shared.IO;
public class ConsoleIOProvider : IIOProvider
{
    public string ReadString() => Console.ReadLine() ?? string.Empty;

    public void WriteString(string @string) => Console.WriteLine(@string);

}


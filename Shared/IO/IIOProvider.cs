namespace Shared.IO;

public interface IIOProvider
{
    string ReadString();
    void WriteString(string @string);
}

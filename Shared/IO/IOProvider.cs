namespace Shared.IO;

public static partial class IOProvider
{

    public static IIOProvider Instance { get; private set; } = new ConsoleIOProvider();

}
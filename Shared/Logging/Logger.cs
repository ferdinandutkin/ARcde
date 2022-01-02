using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public static partial class Logger
{
    public static ILogger Instance { get; set; } = new ConsoleLogger();
}

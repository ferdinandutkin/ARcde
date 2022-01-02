using Shared.Logging;

namespace Loggers;

public class SecondLogger : FileLogger
{
    public SecondLogger() : base("log1.txt")
    {
    }
}

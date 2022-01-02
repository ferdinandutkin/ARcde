using Shared.Logging;

namespace Loggers;

public class FirstLogger : FileLogger
{
    public FirstLogger() : base("log.txt")
    {
    }
}

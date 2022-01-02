using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public class CompositeLogger : ILogger
{
    private readonly ILogger[] _loggers;
    public CompositeLogger(IEnumerable<ILogger> loggers) => _loggers = loggers.ToArray();
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        foreach (var logger in _loggers)
        {
            logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }

    public bool IsEnabled(LogLevel logLevel) => _loggers.Any(logger => logger.IsEnabled(logLevel));
 
    public IDisposable BeginScope<TState>(TState state) => default!;
 
}

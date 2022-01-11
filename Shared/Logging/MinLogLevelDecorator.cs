using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public class LeveledLoggerDecorator : ILogger
{
    private readonly ILogger _logger;
    private readonly LogLevel _minLogLevel;

    public LeveledLoggerDecorator(ILogger logger, LogLevel minLogLevel)
    {
        _logger = logger;
        _minLogLevel = minLogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (logLevel > _minLogLevel)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        };
    }

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLogLevel && _logger.IsEnabled(logLevel);

    public IDisposable BeginScope<TState>(TState state) => _logger.BeginScope(state);

}
using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public class LeveledLoggerDecorator : ILogger
{
    private readonly ILogger _logger;
    private readonly LogLevel _level;

    public LeveledLoggerDecorator(ILogger logger, LogLevel level)
    {
        _logger = logger;
        _level = level;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (logLevel == _level)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        };
    }

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _level && _logger.IsEnabled(logLevel);

    public IDisposable BeginScope<TState>(TState state) => _logger.BeginScope(state);

}
using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public class ConsoleLogger : ILogger
{
  
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);

        Console.WriteLine($"{logLevel} - {eventId.Id} - {message} - {message}");
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) => default!;

}

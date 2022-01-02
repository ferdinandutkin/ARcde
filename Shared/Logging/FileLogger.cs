using Microsoft.Extensions.Logging;

namespace Shared.Logging;

public class FileLogger : ILogger
{
    private readonly string _fileName;
    public FileLogger(string fileName)
    {
        _fileName = fileName;
    }

    public void Log(string message) => File.AppendAllText(_fileName, message + Environment.NewLine);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);

        File.AppendAllText(_fileName, $"{logLevel} - {eventId.Id} - {message} - {message}{Environment.NewLine}");
    }

    public bool IsEnabled(LogLevel logLevel) => true;
    
    public IDisposable BeginScope<TState>(TState state) => default!;
   
}

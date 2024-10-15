using Microsoft.Extensions.Logging;

namespace SkillsHubV2.BLL.Logging;
public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger (string filePath)
    {
        _filePath = filePath;
    }

    public IDisposable BeginScope<TState> (TState state) => null;

    public bool IsEnabled (LogLevel logLevel)
    {
        return logLevel >= LogLevel.Information;
    }

    public void Log<TState> (LogLevel logLevel, EventId eventId, 
        TState state, Exception exception, 
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var logRecord = $"{DateTime.Now}: {logLevel.ToString()} - {formatter(state, exception)}{Environment.NewLine}";

        File.AppendAllText(_filePath, logRecord);
    }
}

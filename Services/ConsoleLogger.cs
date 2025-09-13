using Microsoft.Extensions.Logging;

namespace MatchupMashup.Services
{
    public class ConsoleLogger : ILogger<NFLDataService>
    {
        public IDisposable BeginScope<Tstate>(Tstate state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            var timestamp = DateTime.Now.ToString("HH:mm:ss");

            // Get color for log level
            var color = GetLogLevelColor(logLevel);

            // Write timestamp in gray
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"[{timestamp}] ");

            // Write log level in approrpriate color
            Console.ForegroundColor = color;
            Console.Write($"[{logLevel}] ");

            // Write message in white
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);

            if (exception != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }

        private ConsoleColor GetLogLevelColor(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Debug => ConsoleColor.Cyan,
                LogLevel.Information => ConsoleColor.Green,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }
    }
}
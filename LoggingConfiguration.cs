using NLog;
using NLog.Targets;

namespace CADShark.Common.Logging
{
    internal class LoggingConfiguration
    {
        internal static void Configure()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Створюємо таргет для логування в консоль
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            // Створюємо таргет для логування в файл
            var fileTarget = new FileTarget();
            fileTarget.FileName = "${basedir}/logs/log.txt";
            config.AddTarget("file", fileTarget);

            // Правила таргетування від Debug до Trace
            config.AddRule(LogLevel.Debug, LogLevel.Trace, consoleTarget);
            config.AddRule(LogLevel.Debug, LogLevel.Trace, fileTarget);

            // Активуємо налаштування
            LogManager.Configuration = config;
        }
    }
}

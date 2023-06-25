using NLog;
using NLog.Targets;

namespace CADShark.Common.Logging
{
    internal class LoggingConfiguration
    {
        internal static void Configure()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/logs/log.txt",
                CreateDirs = true
            };
            config.AddTarget("file", fileTarget);

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget);

            LogManager.Configuration = config;
        }
    }
}

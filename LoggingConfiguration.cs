using NLog;
using NLog.Targets;
using System.Text;

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
                FileName = "${specialfolder:folder=ApplicationData}/CADShark/OpenCAD/Log.txt",
                Encoding = Encoding.UTF8,
                CreateDirs = true,
                Layout = "${longdate}\t${level:uppercase=true}\t${message}"
            };

            config.AddTarget("file", fileTarget);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, consoleTarget);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);

            LogManager.Configuration = config;
        }
    }
}
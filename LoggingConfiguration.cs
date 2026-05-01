using System;
using System.IO;
using Serilog;
using Serilog.Events;

namespace CADShark.Common.Logging
{
    internal static class LoggingConfiguration
    {
        internal static void Configure()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var logDir = Path.Combine(appData, "CADShark");

            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            var logFile = Path.Combine(logDir, "Log.txt");

#if DEBUG
            const LogEventLevel minimumLevel = LogEventLevel.Debug;
#else
            const LogEventLevel minimumLevel = LogEventLevel.Information;
#endif

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(minimumLevel)
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .WriteTo.File(
                    logFile,
                    rollingInterval: RollingInterval.Infinite,
                    fileSizeLimitBytes: 10 * 1024 * 1024,     // 10 MB
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 1,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}\t{Level:u3}\t{Message:lj}{NewLine}{Exception}",
                    shared: true
                )
                .CreateLogger();
        }
    }
}
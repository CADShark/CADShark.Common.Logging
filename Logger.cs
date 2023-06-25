using NLog;

namespace CADShark.Common.Logging
{
    public class Logger
    {
        private static readonly ILogger Loggers = LogManager.GetCurrentClassLogger();
        static Logger()
        {
            LoggingConfiguration.Configure();
        }
        public static void Debug(string message)
        {
            Loggers.Debug(message);
        }
        public static void Info(string message)
        {
            Loggers.Info(message);
        }
        public static void Warning(string message)
        {
            Loggers.Warn(message);
        }
        public static void Error(string message)
        {
            Loggers.Error(message);
        }
        public static void Fatal(string message)
        {
            Loggers.Fatal(message);
        }
        public static void Trace(string message)
        {
            Loggers.Trace(message);
        }
    }
}
using NLog;

namespace CADShark.Common.Logging
{
    public class Logger
    {
        private static readonly ILogger Loggers = LogManager.GetCurrentClassLogger();
        public Logger()
        {
            LoggingConfiguration.Configure();
        }
        public static void Debug(string message)
        {
            Loggers.Debug(message);
        }
        public void Info(string message)
        {
            Loggers.Info(message);
        }
        public void Warning(string message)
        {
            Loggers.Warn(message);
        }
        public void Error(string message)
        {
            Loggers.Error(message);
        }
        public void Fatal(string message)
        {
            Loggers.Fatal(message);
        }
        public void Trace(string message)
        {
            Loggers.Trace(message);
        }
    }
}
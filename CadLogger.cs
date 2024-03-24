using NLog;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using static CADShark.Common.Logging.LoggingConfiguration;
using static NLog.LogManager;

namespace CADShark.Common.Logging
{
    public class CadLogger
    {
        private static ILogger _loggers;

        private CadLogger(string obj0, string obj1)
        {
            Configure();
            _loggers = GetCurrentClassLogger();
        }

        public static CadLogger GetLogger(string className)
        {
            var fullName = Assembly.GetCallingAssembly().FullName;
            return new CadLogger(className, fullName);
        }

        public void Debug(string message)
        {
            _loggers.Debug(message);
        }

        public void Info(string message)
        {
            _loggers.Info(message);
        }

        public void Info(string obg1, string message)
        {
            _loggers.Info("{0}\t{1}", obg1, message);
        }

        public void Warning(string message)
        {
            _loggers.Warn(message);
        }

        public void Error(string message)
        {
            _loggers.Error(message);
        }

        public void Error(string message, Exception exception, [CallerMemberName] string methodName = "")
        {
            _loggers.Error(message);
        }

        public void Fatal(string message)
        {
            _loggers.Fatal(message);
        }

        public void Trace(string message)
        {
            _loggers.Trace(message);
        }
    }
}
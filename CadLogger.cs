using Serilog;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CADShark.Common.Logging
{
    public class CadLogger
    {
        private readonly ILogger _logger;

        private CadLogger(string className, string assemblyName)
        {
            LoggingConfiguration.Configure();
            _logger = Log.ForContext("ClassName", className)
                         .ForContext("AssemblyName", assemblyName);
        }

        public static CadLogger GetLogger<T>()
        {
            var fullName = Assembly.GetCallingAssembly().GetName().Name;
            return new CadLogger(typeof(T).Name, fullName);
        }
        
        public void Debug(string message) => _logger.Debug(message);

        public void Info(string message) => _logger.Information(message);

        public void Info(string obj1, string message) =>
            _logger.Information("{Obj1}\t{Message}", obj1, message);

        public void Warning(string message) => _logger.Warning(message);

        public void Warning(string message, params object[] propertyValues) => _logger.Warning(message, propertyValues);

        public void Error(string message) => _logger.Error(message);

        public void Error(string message, params object[] propertyValues) => _logger.Error(message, propertyValues);


        public void Error(string message, Exception exception, [CallerMemberName] string methodName = "") =>
            _logger.Error(exception, "{Message}\t{MethodName}", message, methodName);

        public void Fatal(string message) => _logger.Fatal(message);

        public void Trace(string message) => _logger.Verbose(message);
    }
}

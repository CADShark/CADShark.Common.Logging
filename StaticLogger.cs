using System;
using System.Runtime.CompilerServices;
using NLog;

namespace CADShark.Common.Logging
{
  public class StaticLogger
  {
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    static StaticLogger()
    {
      var config = new NLog.Config.LoggingConfiguration();

      // Targets where to log to: File and Console
      var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
      var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

      // Rules for mapping loggers to targets            
      config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);
      config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

      // Apply config           
      LogManager.Configuration = config;
    }

    //Exemple Info("Button clicked: Back up and move", nameof (BackupAndMove))
    public static void LogInfo(string message, [CallerMemberName] string methodName = "")
    {
      Logger.Info("{0}: {1}", message, methodName);
    }


    //;

    //
    //public static void Debug(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Debug(text);
    //}
    //public static void Info(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Info(text);
    //}
    //public static void Warning(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Warn(text);
    //}
    //public static void Error(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Error(text);
    //}
    //public static void Fatal(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Fatal(text);
    //}
    //public static void Trace(Type declaringType, string text)
    //{
    //    LogManager.GetLogger(declaringType.FullName).Trace(text);
    //}
  }
}

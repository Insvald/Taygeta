// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using JetBrains.Annotations;
using log4net;
using log4net.Appender;
using log4net.Core;
using Microsoft.Framework.Logging;
using ILogger = Microsoft.Framework.Logging.ILogger;

namespace Taygeta.Repositories.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _log;
        
        public Log4NetLogger([NotNull] string name)
        {
            _log = LogManager.GetLogger(name);
        }

        private static Level DeriveLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    return Level.All;                    
                case LogLevel.Verbose:
                    return Level.Verbose;
                case LogLevel.Information:
                    return Level.Info;
                case LogLevel.Warning:
                    return Level.Warn;
                case LogLevel.Error:
                    return Level.Error;
                case LogLevel.Critical:
                    return Level.Critical;
                default:
                    return null;
            }
        }

        /// <inheritdoc />
        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            string message = formatter != null ? formatter(state, exception) : LogFormatter.Formatter(state, exception);
            if (!string.IsNullOrWhiteSpace(message))
                _log.Logger.Log(null, DeriveLogLevel(logLevel), message, exception);
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return _log.Logger.IsEnabledFor(DeriveLogLevel(logLevel));
        }

        /// <inheritdoc />
        public IDisposable BeginScopeImpl(object state)
        {
            return new NoopDisposable();
        }

        /// <summary>
        /// Stub for IDisposable
        /// </summary>
        private class NoopDisposable : IDisposable
        {
            public void Dispose() { }
        }
    }

    public static class LoggerExtension
    {
        /// <summary>
        /// Flush all buffered logs
        /// </summary>
        public static void Flush([CanBeNull] this ILogger logger)
        {
            foreach (IAppender appender in LogManager.GetRepository().GetAppenders())
                (appender as BufferingAppenderSkeleton)?.Flush();
        }
    }
}

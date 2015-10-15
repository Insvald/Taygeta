// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using JetBrains.Annotations;
using log4net.Appender;
using log4net.Core;
using Taygeta.Repositories.Models;

namespace Taygeta.Repositories.Logging
{
    /// <summary>
    /// Log4Net appender using IDataSupplier to save log entries
    /// </summary>
    public class DataSupplierAppender : BufferingAppenderSkeleton
    {
        public IDataSupplier DataSupplier { get; set; }

        protected override void SendBuffer([NotNull] LoggingEvent[] events)
        {
            if (DataSupplier == null)
                throw new ArgumentNullException(nameof(DataSupplier), "The property should be set prior to logging events.");

            foreach (LoggingEvent logEvent in events)
                DataSupplier.LogEntries.Add(
                    new LogEntry(
                        logEvent.TimeStamp,
                        logEvent.ThreadName,
                        logEvent.Level.ToString(),
                        logEvent.LoggerName,
                        logEvent.RenderedMessage,
                        logEvent.GetExceptionString()));

            DataSupplier.Save();
        }
    }
}

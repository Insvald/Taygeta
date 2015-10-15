// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using log4net;
using log4net.Appender;
using log4net.Config;
using Microsoft.Framework.Logging;
using ILoggerFactory = Microsoft.Framework.Logging.ILoggerFactory;

namespace Taygeta.Repositories.Logging
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        // TODO: add other ways to configure (json, in code)
        /// <summary>
        /// Initializes a new log4net logger provider using an XML file
        /// </summary>
        /// <param name="xmlConfig">path to an XML config file</param>
        /// <param name="dataSupplier">optional <see cref="IDataSupplier"/> implementation for saving log entries through it</param>
        public Log4NetLoggerProvider([NotNull] string xmlConfig, IDataSupplier dataSupplier = null)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(xmlConfig));
            
            //setup DataSupplierAppenders, if any
            if (dataSupplier != null)
                foreach (IAppender appender in LogManager.GetRepository().GetAppenders())
                {
                    DataSupplierAppender dataSupplierAppender = appender as DataSupplierAppender;
                    if (dataSupplierAppender != null)
                        dataSupplierAppender.DataSupplier = dataSupplier;
                }
        }
        
        /// <inheritdoc />
        public void Dispose()
        {
            LogManager.Shutdown();
            GC.SuppressFinalize(this);
        }

        ~Log4NetLoggerProvider()
        {
            LogManager.Shutdown();
        }

        /// <inheritdoc />
        public ILogger CreateLogger([NotNull] string name)
        {
            return new Log4NetLogger(name);
        }
    }

    public static class Log4NetFactoryExtensions
    {
        public static ILoggerFactory AddLog4Net([NotNull] this ILoggerFactory factory, 
            [NotNull] string xmlConfig, IDataSupplier dataSupplier = null)
        {
            factory.AddProvider(new Log4NetLoggerProvider(xmlConfig, dataSupplier));
            return factory;
        }
    }
}

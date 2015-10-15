// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Xunit;
using Taygeta.Repositories.Logging;

namespace Taygeta.Repositories.Test
{
    public class Log4NetLoggerTest
    {
        [Fact]
        public void CheckThatLoggerWorksWithoutExceptions()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ILoggerFactory loggerFactory = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddLog4Net("Log4Net.config");
            ILogger logger = loggerFactory.CreateLogger<Log4NetLoggerTest>();
            logger.LogInformation("test log message");
        }
    }
}

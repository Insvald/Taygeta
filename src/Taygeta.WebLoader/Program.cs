// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Taygeta.Repositories;
using Microsoft.Framework.Logging;
using Taygeta.Repositories.Logging;

namespace Taygeta.WebLoader
{
    public class Program
    {
        private readonly IDataSupplier _dataSupplier;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public Program(IApplicationEnvironment env)
        {
            try
            {
                // creating infrastructure by ourselves instead of the hosting environment
                ServiceCollection services = new ServiceCollection();
                Startup startup = new Startup(env);
                startup.ConfigureServices(services);
                IServiceProvider serviceProvider = services.BuildServiceProvider();
                _dataSupplier = (IDataSupplier)serviceProvider.GetService(typeof(IDataSupplier));
                ILoggerFactory loggerFactory = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
                startup.Configure(env, loggerFactory, _dataSupplier);
                _config = startup.Configuration;
                _logger = loggerFactory.CreateLogger<Program>();
            }
            catch (Exception ex)
            {
                // just quit after displaying the exception
                Console.WriteLine($"Error occured while initializing the crawler: {ex}");
                Console.ReadLine();
                throw;
            }
        }

        public void Main(string[] args)
        {
            try
            {
                _logger.LogInformation("Starting Main");
                //crawl and save pages to the database
                VacancyCrawler crawler = new VacancyCrawler(new VacancyCrawlConfiguration(_config), _dataSupplier)
                {
                    Cultures = new[] {"en-US", "he-IL"},
                    //Mode = VacancyCrawler.CrawlMode.SingleSite
                    Mode = VacancyCrawler.CrawlMode.Catalog
                };

                _logger.LogInformation("Crawl started");
                //crawler.Crawl(new Uri("http://www.tabtale.com/"));
                crawler.Crawl(new Uri("https://mappedinisrael.com/all-companies/"));
                _logger.LogInformation("Crawl finished");
            }
            catch (Exception ex)
            {
                _logger.LogError(0, (string) null, ex);
                _logger.Flush(); // flush logs immediately in case of error
            }
            finally
            {
                // TODO: save more often, maybe create buffered saving model
                _logger.LogDebug("Trying to save data.");
                _dataSupplier.Save();
                _logger.LogInformation("Data saved");
            }
            Console.WriteLine("Press Enter to close.");
            Console.ReadLine();
        }
    }
}

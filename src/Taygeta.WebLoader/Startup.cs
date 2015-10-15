// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.IO;
using JetBrains.Annotations;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Taygeta.DataAccessLayer;
using Taygeta.Repositories;
using Taygeta.Repositories.Logging;

namespace Taygeta.WebLoader
{
    public class Startup
    {
        public Startup([NotNull] IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices([NotNull] IServiceCollection services)
        {
            services.AddLogging();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddTransient<IDataSupplier, DataContext>();            
        }

        public void Configure([NotNull] IApplicationEnvironment appEnv, 
            [NotNull] ILoggerFactory loggerFactory, [NotNull] IDataSupplier dataSupplier)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddLog4Net(Path.Combine(appEnv.ApplicationBasePath, "Log4Net.config"), dataSupplier);
        }
    }
}

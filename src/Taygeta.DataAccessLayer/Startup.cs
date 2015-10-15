// The Taygeta Project
// (c) 2015 Ilya Rovensky

using JetBrains.Annotations;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Data.Entity;
using Microsoft.Framework.Logging;

namespace Taygeta.DataAccessLayer
{
    public class Startup
    {
        public Startup([NotNull] IHostingEnvironment env, [NotNull] IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            ConfigurationBuilder builder = new ConfigurationBuilder(appEnv.ApplicationBasePath);
            builder.AddJsonFile("config.json");
            builder.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices([NotNull] IServiceCollection services)
        {
            // Add Entity Framework services to the services container.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
        }
    }
}

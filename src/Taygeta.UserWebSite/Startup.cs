// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNet.Authentication.Facebook;
using Microsoft.AspNet.Authentication.MicrosoftAccount;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Localization;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Localization;
using Microsoft.Framework.Logging;
using Taygeta.DataAccessLayer;
using Taygeta.MSHtml;
using Taygeta.Repositories;
using Taygeta.Repositories.Html;
using Taygeta.Repositories.Localization;
using Taygeta.UserWebSite.Models;
using Taygeta.Repositories.Logging;
using System.IO;
using Microsoft.AspNet.Authentication.Google;
using Microsoft.AspNet.Authentication.Twitter;
using Taygeta.UserWebSite.Services;

namespace Taygeta.UserWebSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", true)
                .AddUserSecrets(); // workaround til I know how to set up environment variables in IIS Express

            if (env.IsDevelopment())
            {
                //builder.AddUserSecrets();
                builder.AddApplicationInsightsSettings(true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            /*            
            services.Configure<FacebookAuthenticationOptions>(options =>
            {
                options.AppId = Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            */
            services.Configure<GoogleAuthenticationOptions>(options =>
            {
                options.ClientId = Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });
            /*
            services.Configure<MicrosoftAccountAuthenticationOptions>(options =>
            {
                options.ClientId = Configuration["Authentication:MicrosoftAccount:ClientId"];
                options.ClientSecret = Configuration["Authentication:MicrosoftAccount:ClientSecret"];
            });
            */
            //services.Configure<TwitterAuthenticationOptions>(options =>
            //{
            //    options.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
            //    options.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //});

            services.AddMvc().AddViewLocalization();
            // needed only for localizing strings in resource files
            //services.AddLocalization();

            // Register application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Register my data access layer
            services.AddTransient<IDataSupplier, DataContext>();
            // Register my web page renderer
            services.AddTransient<IPageDocument, MsHtmlPageDocument>();
            // Register my localized resource provider
            services.AddTransient<IStringLocalizerFactory, DbStringLocalizerFactory>();
            // Register my geolocator
            services.AddTransient<IGeoLocator, GeoLocator>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationEnvironment appEnv, ILoggerFactory loggerFactory, IDataSupplier dataSupplier)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory
                .AddConsole()
                .AddLog4Net(Path.Combine(appEnv.ApplicationBasePath, "Log4Net.config"), dataSupplier);

            // The HTTP request pipeline.
            app.UseApplicationInsightsRequestTelemetry();
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseErrorPage();
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
                app.UseErrorHandler("/Home/Error");

            // Track data about exceptions from the application. Should be configured after all error handling middleware in the request pipeline.
            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
            app.UseIdentity();
            //app.UseFacebookAuthentication();
            app.UseGoogleAuthentication();
            //app.UseMicrosoftAccountAuthentication();
            //app.UseTwitterAuthentication();

            // localization settings
            IList<CultureInfo> acceptedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("he-IL"),
                new CultureInfo("ru-RU")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(acceptedCultures[0]),
                SupportedCultures = acceptedCultures,
                SupportedUICultures = acceptedCultures
            });
            
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));            
        }
    }
}

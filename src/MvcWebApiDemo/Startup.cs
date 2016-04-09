using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using WebApplication1.EFRepositoy;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc;
using Serilog;
using System.IO;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;
using WebApplication1.AppConfig;
using Microsoft.Extensions.OptionsModel;

namespace WebApplication1
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        private IConfigurationSection ConfigSection;

        public Startup(IApplicationEnvironment applicationEnvironment, IRuntimeEnvironment runtimeEnvironment)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(applicationEnvironment.ApplicationBasePath);
            builder.AddJsonFile("config.json").AddJsonFile("AppSettings.json").AddEnvironmentVariables();
            Configuration = builder.Build();

            ConfigSection = Configuration.GetSection("AppSettings");
            string logFolder = ConfigSection.Get<AppSettings>().LogSettings.AppLogPath;

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.RollingFile(Path.Combine(applicationEnvironment.ApplicationBasePath, logFolder, "{Date}.txt"))
           .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddEntityFramework().AddSqlServer().AddDbContext<ApplicationContext>(options =>options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddLogging();
            services.Configure<AppSettings>(ConfigSection); //strongly typed AppSettings

            //using Dependency Injection
            services.AddSingleton<IContactsRepository, ContactsRepository>();
            services.AddSingleton<ICallRepository, CallsRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();
            app.UseMvc();

            loggerFactory.AddSerilog();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using WebApplication1.EFRepositoy;
using Microsoft.Data.Entity;
using Serilog;
using System.IO;
using Microsoft.Extensions.Logging;
using WebApplication1.AppConfig;
using WebApplication1.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace WebApplication1
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IApplicationEnvironment applicationEnvironment, IRuntimeEnvironment runtimeEnvironment)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(applicationEnvironment.ApplicationBasePath);
            builder.AddJsonFile("config.json").AddJsonFile("AppSettings.json").AddEnvironmentVariables();
            Configuration = builder.Build();

            string logFolder = Configuration.GetSection("AppSettings").Get<AppSettings>().LogSettings.AppLogPath;

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.RollingFile(Path.Combine(applicationEnvironment.ApplicationBasePath, logFolder, "{Date}.txt"))
           .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddMvcCore().AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());

            //application context
            services.AddEntityFramework().AddSqlServer().
                AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            //identity context
            services.AddEntityFramework().AddSqlServer().
              AddDbContext<ApplicationIdentityContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationIdentityContext,int>()
            .AddDefaultTokenProviders();


            //strongly typed AppSettings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings")); 

            //using Dependency Injection
            services.AddScoped(typeof(UserManager<Identity.ApplicationUser>), typeof(Identity.ApplicationUserManager<Identity.ApplicationUser>));
            services.AddScoped<IApplicationIdentityRepository, ApplicationIdentityRepository>();
            //services.AddSingleton<IContactsRepository, ContactsRepository>();
            //services.AddSingleton<ICallRepository, CallsRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();
            app.UseIdentity();
            app.UseMvc();
            loggerFactory.AddSerilog();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

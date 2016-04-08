﻿using System;
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

namespace WebApplication1
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IApplicationEnvironment applicationEnvironment, IRuntimeEnvironment runtimeEnvironment)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.RollingFile(Path.Combine(applicationEnvironment.ApplicationBasePath, "log-{Date}.txt"))
           .CreateLogger();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //MvcCore - basic package needed for MVC 6 Web API
            services.AddMvcCore().AddJsonFormatters(a => a.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddEntityFramework().AddSqlServer().AddDbContext<ApplicationContext>(options =>options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddMvc();

            //using Dependency Injection
            services.AddSingleton<IContactsRepository, ContactsRepository>();
            services.AddSingleton<ICallRepository, CallsRepository>();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();
            app.UseMvc();

            loggerFactory.AddSerilog();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

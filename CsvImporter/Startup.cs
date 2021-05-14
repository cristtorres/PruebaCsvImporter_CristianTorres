using CsvImporter.Data;
using CsvImporter.Models;
using CsvImporter.Repositories;
using CsvImporter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;

namespace CsvImporter
{
    public static class Startup
    {
 

        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();



            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

      

            IConfiguration configuration = builder.Build();
            var connectionPath = configuration.GetConnectionString("DefaultConnection");
            var path = Environment.CurrentDirectory;

            var ConnectionToAttachSql = connectionPath.Replace("%root%", path);
            services.AddSingleton(configuration);


            //services.AddTransient<IRepository<StockModel>, Repository<StockModel>>();
            //services.AddTransient<IReaderService, LocalReaderCsvService>();
            //services.AddSingleton<EntryPoint>();
            //services.AddTransient<IRepository<StockModel>, Repository<StockModel>>();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "CsvImporter")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            //services.AddLogging(configure => configure.AddSerilog());
            //services.AddLogging(builder =>
            //{

            //});
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog());

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(ConnectionToAttachSql));

            return services;
        }
    }
}

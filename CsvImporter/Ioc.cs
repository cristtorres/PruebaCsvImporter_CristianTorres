using CsvImporter.Data;
using CsvImporter.Repositories;
using CsvImporter.Services;
using CsvImporter.Utils.Strategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter
{
    public class Ioc
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Program>();
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var connectionPath = configuration.GetConnectionString("DefaultConnection");
            var path = System.IO.Directory.GetCurrentDirectory();
            string connectionToAttachSql = string.Empty;
            if (path.Contains("\\bin\\Debug\\netcoreapp3.1"))
            {
                var pathSinfolderBin = path.Replace("\\bin\\Debug\\netcoreapp3.1", string.Empty);
                connectionToAttachSql = connectionPath.Replace("%PATH%", pathSinfolderBin);
            }
            else
            {
                connectionToAttachSql = connectionPath.Replace("%PATH%", path);
            }

            services.AddSingleton(configuration);

            services.AddDbContext<ApplicationDbContext>(
                 options => options.UseSqlServer(connectionToAttachSql));

            /*Configuracion de la estrategia a utilizar para leer el Flat File*/
            services.AddTransient<IStrategy, StrategyFileHelpers>();
            services.AddTransient<IRepository, Repository>();

            services.AddTransient<IReaderService, LocalReaderCsvService>();
            //services.AddSingleton<EntryPoint>();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "CsvImporter")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog());
            return services;
        }
    }
}

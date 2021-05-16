using CsvImporter.Data;
using CsvImporter.Models;
using CsvImporter.Repositories;
using CsvImporter.Services;
using CsvImporter.Utils.Strategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Diagnostics;
using System.IO;

namespace CsvImporter
{
   public class Program
    {
        private readonly ILogger<Program> _logger;
        private readonly IReaderService _reader;
        private readonly IConfiguration _configuration;
        public Program(ILogger<Program> logger, IReaderService reader, IConfiguration configuration)
        {
            _logger = logger;
            _reader = reader;
            _configuration = configuration;
         }

         static void  Main(string[] args)
        {

             var host = CreateHostBuilder(args).Build();
             host.Services.GetRequiredService<Program>().Execute();
        }


        public bool Execute()
        {
            try
            {
                _logger.LogInformation("iniciando el programa...");
                Console.WriteLine("Por favor ingrese el path completo del archivo Csv a cargar ...");
                var path = Console.ReadLine();
                var delimiter = _configuration.GetSection("CsvSettings").GetValue<String>("Delimiter");
                Directory.SetCurrentDirectory(@"C:\");
                _reader.Read(path, delimiter);
                _logger.LogInformation("Fin del programa");
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error al procesar el archivo csv ", exception.Message);
                return false;
               
            }

        }

        /// <summary>
        /// Creacion del Host con la registracion de servicios
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    Ioc.ConfigureServices(services);
                    //services.AddTransient<Program>();
                    //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    //var builder = new ConfigurationBuilder()
                    //    .AddJsonFile($"appsettings.json", true, true)
                    //    .AddJsonFile($"appsettings.{env}.json", true, true)
                    //    .AddEnvironmentVariables();

                    //IConfiguration configuration = builder.Build();
                    //var connectionPath = configuration.GetConnectionString("DefaultConnection");
                    //var path = System.IO.Directory.GetCurrentDirectory();
                    //string connectionToAttachSql = string.Empty;
                    //if (path.Contains("\\bin\\Debug\\netcoreapp3.1"))
                    //{
                    //   var pathSinfolderBin = path.Replace("\\bin\\Debug\\netcoreapp3.1", string.Empty);
                    //      connectionToAttachSql = connectionPath.Replace("%PATH%", pathSinfolderBin);
                    //}
                    //else
                    //{
                    //      connectionToAttachSql = connectionPath.Replace("%PATH%", path);
                    //}

                    //services.AddSingleton(configuration);

                    //services.AddDbContext<ApplicationDbContext>(
                    //     options => options.UseSqlServer(connectionToAttachSql));

                    // services.AddTransient<IStrategy, StrategyStreamReader>();
                    //services.AddTransient<IRepository,Repository>();

                    //services.AddTransient<IReaderService, LocalReaderCsvService>();
                    ////services.AddSingleton<EntryPoint>();
 
                    //Log.Logger = new LoggerConfiguration()
                    //    .Enrich.FromLogContext()
                    //    .Enrich.WithProperty("Application", "CsvImporter")
                    //    .ReadFrom.Configuration(configuration)
                    //    .CreateLogger();
 
                    //services.AddLogging(loggingBuilder =>
                    //    loggingBuilder.AddSerilog());
                });
        }


    }
}

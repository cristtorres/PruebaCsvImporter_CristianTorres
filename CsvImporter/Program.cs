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
                });
        }


    }
}

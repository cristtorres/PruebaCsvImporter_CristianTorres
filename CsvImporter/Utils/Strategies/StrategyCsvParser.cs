
using CsvImporter.Models;
using CsvImporter.Models.Mappers;
using Microsoft.Extensions.Logging;
using NReco.Csv;
using SoftCircuits.CsvParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
 

namespace CsvImporter.Utils.Strategies
{
    class StrategyCsvParser : IStrategy
    {

        private readonly ILogger<StrategyCsvParser> _logger;
        public StrategyCsvParser(ILogger<StrategyCsvParser> logger)
        {
            _logger = logger;
        }
        public List<StockModel> ExecuteAlgorithm(string path, string delimiter)
        {

            List<StockModel> registrosAInsertar = new List<StockModel>();
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<StockModel> models = new List<StockModel>();
            CsvSettings settings = new CsvSettings
            {
                ColumnDelimiter = ';'
            };
            using (CsvReader<StockModel> reader = new CsvReader<StockModel>(path,settings))
            {
                // Read header and use to determine column order
                reader.MapColumns<StockMapper>();
                reader.ReadHeaders(true);
                // Read data
                while (reader.Read(out StockModel model))
                    models.Add(model);
            }

            stopwatch.Stop();
            _logger.LogInformation($" {stopwatch.Elapsed.TotalSeconds} Segundos - Tiempo ejecutado para leer el archivo  usando CsvPArser");
            return models;
        }
    }
}

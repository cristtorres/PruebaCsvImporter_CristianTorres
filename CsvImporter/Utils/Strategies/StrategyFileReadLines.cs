using CsvImporter.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
 

namespace CsvImporter.Utils.Strategies
{
    class StrategyFileReadLines: IStrategy
    {

        private readonly ILogger<StrategyFileReadLines> _logger;
        public StrategyFileReadLines(ILogger<StrategyFileReadLines> logger)
        {
            _logger = logger;
        }

        public List<StockModel> ExecuteAlgorithm(string path, string delimiter)
        {

            List<StockModel> registrosAInsertar = new List<StockModel>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //var sumOfLines = ;

            foreach (var item in File.ReadLines(path).Select(line => line.Split(delimiter)))
            {
                registrosAInsertar.Add(new StockModel
                {
                    PointOfSale = item[0],
                    Product = item[1],
                    Date = item[2],
                    Stock = item[3]
                });
            }

            stopwatch.Stop();
            _logger.LogInformation($" {stopwatch.Elapsed.TotalSeconds} Segundos - Tiempo ejecutado para leer el archivo  usando File-ReadLines");
            return registrosAInsertar;
        }
    }
}

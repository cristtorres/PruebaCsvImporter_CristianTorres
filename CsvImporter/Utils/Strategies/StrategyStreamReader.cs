using CsvImporter.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace CsvImporter.Utils.Strategies
{

    public class StrategyStreamReader : IStrategy
    {
        private readonly ILogger<StrategyStreamReader> _logger;
        private ILogger<StrategyFileHelpers> @object;

        public StrategyStreamReader(ILogger<StrategyStreamReader> logger)
        {
            _logger = logger;
        }

        public List<StockModel> ExecuteAlgorithm(string path, string delimiter)
        {
            List<StockModel> registrosAInsertar = new List<StockModel>();
            try
            {
                string line;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                using (var fs = File.OpenRead(Path.GetFullPath(path)))
                using (var reader = new StreamReader(fs))
                    while ((line = reader.ReadLine()) != null)
                    {
                        var csvLine = line.Split(delimiter);
                        StockModel model = new StockModel { PointOfSale = csvLine[0], Product = csvLine[1], Date = csvLine[2], Stock = csvLine[3] };
                        registrosAInsertar.Add(model);
                    }
                stopwatch.Stop();
                _logger.LogInformation($" {stopwatch.Elapsed.TotalSeconds} Segundos - Tiempo ejecutado para leer todo el file con StreamReader C#");
 
                return registrosAInsertar;   
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return registrosAInsertar;
            }
            finally
            {
                if (registrosAInsertar.Count > 0)
                    registrosAInsertar.RemoveAt(0);
            }

        }

}
}

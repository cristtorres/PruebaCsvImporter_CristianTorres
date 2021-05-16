using CsvImporter.Models;
using FileHelpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CsvImporter.Utils.Strategies
{
    public class StrategyFileHelpers : IStrategy
    {
        private readonly ILogger<StrategyFileHelpers> _logger;
        public StrategyFileHelpers(ILogger<StrategyFileHelpers> logger)
        {
            _logger = logger;
        }
        List<StockModel> IStrategy.ExecuteAlgorithm(string path, string delimiter)
        {
            List<StockModel> registrosAInsertar = new List<StockModel>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var engine = new FileHelperAsyncEngine<StockModel>();
            using (engine.BeginReadFile( path))
                foreach (var record in engine)
                {
                    registrosAInsertar.Add(record);
                }
            stopwatch.Stop();
            _logger.LogInformation($" {stopwatch.Elapsed.TotalSeconds} Segundos - Tiempo ejecutado para leer todo el file con FileHelpers");

            return registrosAInsertar;
        }
    }
}

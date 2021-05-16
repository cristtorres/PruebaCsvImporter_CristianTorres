using CsvHelper;
using CsvHelper.Configuration;
using CsvImporter.Models;
using CsvImporter.Models.Mappers;
using CsvImporter.Repositories;
using CsvImporter.Utils;
using CsvImporter.Utils.Exceptions;
using CsvImporter.Utils.Strategies;
using FileHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CsvImporter.Services
{
    public class LocalReaderCsvService : IReaderService
    {
        #region variables
        private readonly ILogger<LocalReaderCsvService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRepository _repository;
        private readonly IStrategy _strategyReader;
        #endregion  

        #region constructors
        public LocalReaderCsvService(ILogger<LocalReaderCsvService> logger, IConfiguration config, IRepository repository, IStrategy strategy)
        {
            _logger = logger;
            _configuration = config;
            _repository = repository;
            _strategyReader = strategy;

        }
        #endregion  

        #region methods
        /// <summary>
        /// Lee un archivo csv de una carpeta local para insertar en la BD. 
        /// </summary>
        /// <param name="path">path del csv</param>
        /// <param name="delimiter">delimitador</param>
        /// <returns>Si se ejecuta bien retorna la cantidad de filas leidas insertadas</returns>
        public async Task<int> Read(string path, string delimiter)
        {
            List<StockModel> registrosAInsertar = new List<StockModel>();
            try
            {
                var extensionFile =   Path.GetExtension(path).ToUpper(); 
                if (!extensionFile.Contains(".CSV") )
                {
                   throw new FileFormatNotSupportedException(path);
                }
                _logger.LogInformation("Leyendo archivo ...");
                await _repository.Clear();
                registrosAInsertar = _strategyReader.ExecuteAlgorithm(path, delimiter);
                _logger.LogInformation($"Archivo leido - {registrosAInsertar.Count} lineas");
                await _repository.InsertRange(registrosAInsertar);
                return registrosAInsertar.Count;
            }
            catch (Exception e)
            {
                 _logger.LogWarning($"Error al procesar el archivo Csv :{path}", e.StackTrace);
                return registrosAInsertar.Count;
            }
 
        }
 
        #endregion
    }
}

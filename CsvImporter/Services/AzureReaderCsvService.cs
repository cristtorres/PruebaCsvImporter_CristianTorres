using Azure.Storage.Blobs.Specialized;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvImporter.Services
{
    class AzureReaderCsvService : IReaderService
    {
        private readonly ILogger<IReaderService> _logger;
        private readonly IConfiguration _configuration;

        public AzureReaderCsvService(ILogger<IReaderService> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;

        }
 
        /// <summary>
        /// Lectura de un archivo Csv cargado en una cuenta de Azure Blob Storage
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<int> IReaderService.Read(string path, string delimiter)
        {
            throw new NotImplementedException();
        }
    }
}

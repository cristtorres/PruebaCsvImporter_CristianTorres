using CsvImporter;
using CsvImporter.Repositories;
using CsvImporter.Services;
using CsvImporter.Utils.Strategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CsvImporterTest
{
    public class ProgramTest
    {
    
        public ProgramTest()
        {

           
            var _logger = new Mock<ILogger<IReaderService>>();
            var _configuration = new Mock<IConfiguration>();
            var _repository = new Mock<IRepository>();
            var _strategy = new Mock<IStrategy>();
            //var mockServiceReader = new LocalReaderCsvService(_logger,_configuration, _repository, (IStrategy)_strategy);
            //mockService.Setup(s => s.Get()).Returns(Task.FromResult(resourceLists));
            //_reader = new LocalReaderCsvService();
        }
        [Theory]
        [InlineData("path","delimiter")]
        public async Task When_is_loading_csvFile_with_invalidformat_returns_false(string path, string delimiter)
        {
            var pathFile =  "C:\\DEsarrollo\\Ejemplos\\ImporterCSV\PruebaCsvImporter_CristianTorres\\CsvImporter\\LoadFiles\\Stock.CSV";
        
             
            
        }
        //[Theory]
        //[InlineData("cristn.torres", "1450006")]
        //public async Task loginNotOk(string username, string pass)

        //}
    }
}

using CsvImporter;
using CsvImporter.Models;
using CsvImporter.Repositories;
using CsvImporter.Services;
using CsvImporter.Utils.Strategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CsvImporterTest
{
    public class ServiceReaderShould
    {
        private  LocalReaderCsvService mockServiceReader;
        public ServiceReaderShould()
        {

           
            var _logger = new Mock<ILogger<LocalReaderCsvService>>();
            var _configuration = new Mock<IConfiguration>();
            var _repository = new Mock<IRepository>();
            var _strategy = new Mock<IStrategy>();
             _repository.Setup(m => m.Clear()).Returns(() => Task.FromResult(Stubs.StubStock.Clear()));
            _repository.Setup(m => m.Count()).ReturnsAsync(Stubs.StubStock.Count());
            _repository.Setup(m => m.InsertRange(It.IsAny<List<StockModel>>())).Returns((List<StockModel> csvLines) => Task.FromResult(Stubs.StubStock.InsertRange(csvLines)));

              mockServiceReader = new LocalReaderCsvService(_logger.Object,_configuration.Object, _repository.Object, _strategy.Object);
             //_reader = new LocalReaderCsvService();
        }
        [Theory]
        [InlineData("stock1.csv",";")]
        [InlineData("Stock2.csv", ";")]

        public async Task validate_load_success__from_csvFile__returns_linesAdded(string file, string delimiter)
        {
            var pathFile   = $"{Environment.CurrentDirectory}\\Files\\{file}";
            var result = await mockServiceReader.Read(pathFile, delimiter);


        }
        //[Theory]
        //[InlineData("cristn.torres", "1450006")]
        //public async Task loginNotOk(string username, string pass)

        //}
    }
}

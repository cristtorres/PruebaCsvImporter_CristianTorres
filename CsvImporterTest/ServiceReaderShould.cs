using CsvImporter;
using CsvImporter.Models;
using CsvImporter.Repositories;
using CsvImporter.Services;
using CsvImporter.Utils.Exceptions;
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

            Mock<ILogger<LocalReaderCsvService>> _logger = new Mock<ILogger<LocalReaderCsvService>>();
            Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
            Mock<IRepository>   _repository = new Mock<IRepository>();

            Mock<ILogger<StrategyStreamReader>> _loggerStrategy = new Mock<ILogger<StrategyStreamReader>>();
            StrategyStreamReader _strategy = new StrategyStreamReader(_loggerStrategy.Object);


            var csvTest1 = $"{Environment.CurrentDirectory}\\Files\\Stock1.csv";
            
            
            //_strategy.Setup(s => s.ExecuteAlgorithm(csvTest1,";")).Returns(() => Stubs.StubStrategy.AllStocksRead());
            _repository.Setup(m => m.Clear()).Returns(() => Task.FromResult(Stubs.StubRepository.Clear()));
            _repository.Setup(m => m.Count()).ReturnsAsync(Stubs.StubRepository.Count());
            _repository.Setup(m => m.InsertRange(It.IsAny<List<StockModel>>())).Returns((List<StockModel> csvLines) => Task.FromResult(Stubs.StubRepository.InsertRange(csvLines)));

              mockServiceReader = new LocalReaderCsvService(_logger.Object,_configuration.Object, _repository.Object, _strategy);
              
        }
        [Theory]
        [InlineData("stock1.csv", ";", 6)]
        [InlineData("stock3.csv", ";", 500)]

        public async Task validate_successful_upload__from_csvFile__returns_linesAdded(string file, string delimiter, int recordsExpected)
        {
            var pathFile = $"{Environment.CurrentDirectory}\\Files\\{file}";
            var result = await mockServiceReader.Read(pathFile, delimiter);
            Assert.True(result == recordsExpected);
        }
        [Theory]
        [InlineData("stock4.csv", ";", 30)]
        public async Task validate_successful_upload_partial__from_csvFile_witherrorLines__returns_linesAdded(string file, string delimiter, int recordsExpected)
        {
            var pathFile = $"{Environment.CurrentDirectory}\\Files\\{file}";
            var result = await mockServiceReader.Read(pathFile, delimiter);
            Assert.True(result == recordsExpected);
        }
        [Theory]
        [InlineData("stock2.txt", ";")]
        public async Task validate_failed_upload_from_file_with_invalidformat__raise_FileFormatNotSupportedException(string file, string delimiter)
        {
           var pathFile = $"{Environment.CurrentDirectory}\\Files\\{file}";
           await Assert.ThrowsAsync<FileFormatNotSupportedException>(() => mockServiceReader.Read(pathFile, delimiter));
        }
    }
}

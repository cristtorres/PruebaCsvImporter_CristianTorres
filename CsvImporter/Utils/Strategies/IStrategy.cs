using CsvImporter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Utils.Strategies
{
    public interface IStrategy
    {
          List<StockModel> ExecuteAlgorithm(string path, string delimiter);
    }
}

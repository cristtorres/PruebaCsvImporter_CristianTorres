using CsvImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvImporterTest.Stubs
{
    public class StubStock
    {
        private static List<StockModel> stocksCargados = new List<StockModel>();
        public static bool Clear() {
            stocksCargados.Clear();
            return true;
        }
        public static int Count()
        {
        
            return stocksCargados.Count();
        }

        public static int InsertRange(List<StockModel> listaStocksAcargar)
        {
            stocksCargados.AddRange(listaStocksAcargar);
            return stocksCargados.Count();
        }
    }
}

using CsvImporter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporterTest.Stubs
{
    public class StubStrategy
    {
        public static List<StockModel> AllStocksRead()
        {

            var listaStocksLeidos = new List<StockModel>()
            {
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-17", Stock = "2" },
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-18", Stock = "2" },
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-19", Stock = "2" },
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-20", Stock = "2" },
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-21", Stock = "2" },
                new StockModel{ PointOfSale="121017", Product= "17240503103734", Date="2019-08-22", Stock = "2" }
            };
            return listaStocksLeidos;
        }
    }
}

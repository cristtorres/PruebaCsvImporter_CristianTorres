
using SoftCircuits.CsvParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CsvImporter.Models.Mappers
{
    public sealed class StockMapper : ColumnMaps<StockModel>
    {
        public StockMapper()
        {
            // Note that only those properties set, and only those columns referenced
            // will be modified. All columns and settings not referenced here retain
            // their previous values.
            MapColumn(m => m.PointOfSale).Index(0);
            MapColumn(m => m.Product).Index(1);
            MapColumn(m => m.Date).Index(2);
            MapColumn(m => m.Stock).Index(3);

      
            //AutoMap(CultureInfo.InvariantCulture);
            ////Map(m => m.Id).Ignore();
            //MapColumn(x => x.PointOfSale).Name("PointOfSale").Index(0);
            //Map(x => x.Product).Name("Product").Index(1);
            //Map(x => x.Date).Name("Date").Index(2);
            //Map(x => x.Date).Name("Stock").Index(3);
        }
    }
 
}

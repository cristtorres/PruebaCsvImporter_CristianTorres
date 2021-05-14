using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Utils
{
    public static class DateFactory
    {
        /// <summary>
        /// Parsea un string con formato fecha 2019-08-17 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>el datetime en base al string recibido</returns>
        public static DateTime CreateDateTime(string fecha)
        {
            //2019 - 08 - 17
            var valuesDate = fecha.Split("-");
            var day = int.Parse( valuesDate[2]);
            var month = int.Parse(valuesDate[1]);
            var year = int.Parse(valuesDate[0]);

            return new DateTime(year, month, day);
        }
    }
}

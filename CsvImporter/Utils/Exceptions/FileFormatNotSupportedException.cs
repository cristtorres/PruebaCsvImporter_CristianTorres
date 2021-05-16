using System;
using System.Collections.Generic;
using System.Text;

namespace CsvImporter.Utils.Exceptions
{
    public class FileFormatNotSupportedException :  Exception
    {
        public FileFormatNotSupportedException()
        {

        }

        public FileFormatNotSupportedException(string pathName)
            : base(String.Format("Invalid file : {0}", pathName))
        {

        }

    }
}

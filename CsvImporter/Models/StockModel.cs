using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CsvImporter.Models
{
    [DelimitedRecord(";"), IgnoreFirst(1)]
    [Table("Stock")]
    public class StockModel
    {

        //[FieldHidden]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
        [Required]
        [Display(Name = "PointOfSale")]
        public string PointOfSale { get; set; }

        [Required]
        [Display(Name = "ProductNumber")]
        public string Product { get; set; }

        [Required]
        [Display(Name = "Date")]
        //[FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        public string Date { get; set; }


        [Required]
        [Display(Name = "CurrentStock")]
        public string Stock { get; set; }

    }
}

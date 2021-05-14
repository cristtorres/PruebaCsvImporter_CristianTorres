 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace CsvImporter.Models
{
    [NotMapped]
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

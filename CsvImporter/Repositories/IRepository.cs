using CsvImporter.Models;
using System.Collections.Generic;
 using System.Threading.Tasks;

namespace CsvImporter.Repositories
{
    public interface IRepository 
    {
        Task<IEnumerable<StockModel>> GetAll();
 
        Task Clear();
        Task InsertRange(System.Collections.Generic.List<StockModel> entities);
    }
}

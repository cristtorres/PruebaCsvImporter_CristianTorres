 
using System.Threading.Tasks;

namespace CsvImporter.Services
{
    public interface IReaderService
    {
        Task<int> Read(string path, string delimiter);
    }
}

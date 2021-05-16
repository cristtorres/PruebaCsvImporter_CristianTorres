
using CsvImporter.Models;
using Microsoft.EntityFrameworkCore;
 

namespace CsvImporter.Data
{
    public class ApplicationDbContext: DbContext
    {
            
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StockModel> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                     .Entity<StockModel>(builder =>
                     {
                         builder.HasKey(o => new { o.PointOfSale,o.Product, o.Date,o.Stock });
                         builder.ToTable("Stock");
                     });
        }

    }
 
  
}

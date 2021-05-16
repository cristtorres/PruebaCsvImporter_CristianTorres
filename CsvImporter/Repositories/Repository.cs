using CsvImporter.Data;
using CsvImporter.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace CsvImporter.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<Repository> _logger;
        private readonly IConfiguration _configuration;
        public Repository(ApplicationDbContext context, ILogger<Repository> logger, IConfiguration configuration)
        {
            _db = context;
            _logger = logger;
            _configuration = configuration;
        }

        protected string GetConnection()
        {
            var connectionToAttachSql = String.Empty;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            var path = Environment.CurrentDirectory;
            if (path.Contains("\\bin\\Debug\\netcoreapp3.1"))
            {
                var pathSinfolderBin = path.Replace("\\bin\\Debug\\netcoreapp3.1", string.Empty);
                connectionToAttachSql = connectionString.Replace("%PATH%", pathSinfolderBin);
            }
            else
            {
                connectionToAttachSql = connectionString.Replace("%PATH%", path);
            }
            return  connectionToAttachSql.ToString();
        }

        /// <summary>
        /// Elimina todos los registros de la tabla Stock
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Clear()
        {
            try
            {
                _logger.LogInformation("Eliminando datos de la tabla..");
                _db.Database.ExecuteSqlRaw("truncate table stock");            
                _db.SaveChanges();
                _logger.LogInformation("Tabla actualizada para la insercion masiva ");
                return true; 
            }
            catch (Exception exception)
            {
                _logger.LogError("Error en el Borrado de datos de Tabla", exception.StackTrace);
                return false;
            }
            finally
            {
                await _db.Database.CloseConnectionAsync();
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StockModel>> GetAll()
        {
            return  await  _db.Stocks.ToListAsync();
        }

        /// <summary>
        /// Agrega un conjunto de regitros
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task InsertRange(List<StockModel> entities)
        {
            //using var transaction = _db.Database.BeginTransaction();
            try
            {
                DapperPlusManager.Entity<StockModel>().BatchTimeout(180).BatchSize(500);
                
                using (var connection = new SqlConnection( GetConnection())) 
                {
                     connection.BulkInsert(entities);
                }
 
                _logger.LogInformation("Los datos del archivo fueron insertados correctamente en BD");

            }
            catch (Exception ex)
            {
                _logger.LogError("Error al insertar masivamente en la DB ", ex.Message);
            }
            finally
            {
                await _db.Database.CloseConnectionAsync();
            }
        }

        public async Task<int> Count()
        {
            return await  _db.Stocks.CountAsync();
        }
    }
 
 
}

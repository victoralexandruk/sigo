using Dapper;
using Microsoft.Extensions.Configuration;
using SIGO.Common.Data;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SIGO.Normas.Data
{
    public class NormaRepository : IRepository<Norma>
    {
        public static void ConfigureDB(IConfiguration configuration)
        {
            using (SqlConnection db = new SqlConnection(configuration.GetConnectionString("NormasConnection")))
            {
                DataHelper.CreateTableIfNotExists<Norma>(db, "Norma", "normas_seed.json");
            }
        }

        private readonly string _connectionString;

        public NormaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("NormasConnection");
        }

        public IEnumerable<Norma> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<Norma>("SELECT * FROM Norma WITH(NOLOCK)");
            }
        }

        public Norma GetById(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Norma>("SELECT * FROM Norma WITH(NOLOCK) WHERE Id = @id", new { id });
            }
        }

        public void Save(Norma model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (model.Id > 0)
                {
                    DataHelper.Update(db, "Norma", model);
                }
                else
                {
                    model.Id = DataHelper.Insert(db, "Norma", model);
                }
            }
        }

        public IEnumerable<Norma> Search(IDictionary<string, object> where, bool strict = true)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return DataHelper.Search<Norma>(db, "Norma", where, strict);
            }
        }
    }
}

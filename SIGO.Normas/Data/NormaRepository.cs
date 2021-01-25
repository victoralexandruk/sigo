using Dapper;
using Microsoft.Extensions.Configuration;
using SIGO.Common.Data;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIGO.Normas.Data
{
    public class NormaRepository : IRepository<Norma>
    {
        public static void ConfigureDB(IConfiguration configuration)
        {
            using (SqlConnection db = new SqlConnection(configuration.GetConnectionString("NormasConnection")))
            {
                BaseRepository.CreateTableIfNotExists<Norma>(db, "Norma", "normas_seed.json");
            }
        }

        private readonly IConfiguration _config;

        public NormaRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Norma> GetAll()
        {
            using (SqlConnection db = new SqlConnection(_config.GetConnectionString("NormasConnection")))
            {
                return db.Query<Norma>("SELECT * FROM Norma");
            }
        }
    }
}

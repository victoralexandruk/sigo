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
    public class AcaoPlanejadaRepository : IRepository<AcaoPlanejada>
    {
        private readonly string _connectionString;

        public AcaoPlanejadaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("NormasConnection");
        }

        public IEnumerable<AcaoPlanejada> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<AcaoPlanejada>("SELECT * FROM AcaoPlanejada WITH(NOLOCK)");
            }
        }

        public AcaoPlanejada GetById(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var acaoPlanejada = db.QueryFirstOrDefault<AcaoPlanejada>("SELECT * FROM AcaoPlanejada WITH(NOLOCK) WHERE Id = @id", new { id });
                return acaoPlanejada;
            }
        }

        public void Save(AcaoPlanejada model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (model.Id > 0)
                {
                    DataHelper.Update(db, "AcaoPlanejada", model);
                }
                else
                {
                    model.Id = DataHelper.Insert(db, "AcaoPlanejada", model);
                }
            }
        }

        public void Delete(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute("DELETE FROM AcaoPlanejada WHERE Id = @id", new { id });
            }
        }

        public IEnumerable<AcaoPlanejada> Search(IDictionary<string, object> where, bool strict = true)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return DataHelper.Search<AcaoPlanejada>(db, "AcaoPlanejada", where, strict);
            }
        }
    }
}

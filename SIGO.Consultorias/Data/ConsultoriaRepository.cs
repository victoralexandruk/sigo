using Dapper;
using Microsoft.Extensions.Configuration;
using SIGO.Common.Data;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SIGO.Consultorias.Data
{
    public class ConsultoriaRepository : IRepository<Consultoria>
    {
        private readonly string _connectionString;

        public ConsultoriaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConsultoriasConnection");
        }

        public IEnumerable<Consultoria> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<Consultoria>("SELECT * FROM Consultoria WITH(NOLOCK)");
            }
        }

        public Consultoria GetById(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var consultoria = db.QueryFirstOrDefault<Consultoria>("SELECT * FROM Consultoria WITH(NOLOCK) WHERE Id = @id", new { id });
                return consultoria;
            }
        }

        public void Save(Consultoria model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (model.Id > 0)
                {
                    DataHelper.Update(db, "Consultoria", model);
                }
                else
                {
                    model.Id = DataHelper.Insert(db, "Consultoria", model);
                }
            }
        }

        public IEnumerable<Consultoria> Search(IDictionary<string, object> where, bool strict = true)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return DataHelper.Search<Consultoria>(db, "Consultoria", where, strict);
            }
        }
    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using SIGO.Common.Data;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIGO.Consultorias.Data
{
    public class EmpresaRepository : IRepository<Empresa>
    {
        private readonly string _connectionString;

        public EmpresaRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConsultoriasConnection");
        }

        public IEnumerable<Empresa> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<Empresa>("SELECT * FROM Empresa WITH(NOLOCK)");
            }
        }

        public Empresa GetById(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var empresa = db.QueryFirstOrDefault<Empresa>("SELECT * FROM Empresa WITH(NOLOCK) WHERE Id = @id", new { id });
                return empresa;
            }
        }

        public void Save(Empresa model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (model.Id > 0)
                {
                    DataHelper.Update(db, "Empresa", model);
                }
                else
                {
                    model.Id = DataHelper.Insert(db, "Empresa", model);
                }
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> Search(IDictionary<string, object> where, bool strict = true)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return DataHelper.Search<Empresa>(db, "Empresa", where, strict);
            }
        }
    }
}

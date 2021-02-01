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
    public class ContratoRepository : IRepository<Contrato>
    {
        private readonly string _connectionString;

        public ContratoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ConsultoriasConnection");
        }

        public IEnumerable<Contrato> GetAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<Contrato>("SELECT * FROM Contrato WITH(NOLOCK)");
            }
        }

        public Contrato GetById(long id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var contrato = db.QueryFirstOrDefault<Contrato>("SELECT * FROM Contrato WITH(NOLOCK) WHERE Id = @id", new { id });
                if (!string.IsNullOrEmpty(contrato?.Cnpj))
                {
                    contrato.Empresa = db.QueryFirstOrDefault<Empresa>("SELECT * FROM Empresa WITH(NOLOCK) WHERE Cnpj = @Cnpj", new { Cnpj = contrato.Cnpj });
                }
                return contrato;
            }
        }

        public void Save(Contrato model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                if (model.Id > 0)
                {
                    DataHelper.Update(db, "Contrato", model);
                }
                else
                {
                    model.Id = DataHelper.Insert(db, "Contrato", model);
                }
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contrato> Search(IDictionary<string, object> where, bool strict = true)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return DataHelper.Search<Contrato>(db, "Contrato", where, strict);
            }
        }
    }
}

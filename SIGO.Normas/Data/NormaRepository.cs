using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SIGO.Common;
using SIGO.Domain.Common;
using SIGO.Domain.Normas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SIGO.Normas.Data
{
    public class NormaRepository : IRepository<Norma>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] StatusList = new[]
        {
            "Em Vigor", "Cancelada"
        };

        private static readonly string[] OrganismoList = new[]
        {
            "ABNT", "ISO", "IEC", "DIN", "BSI", "AFNOR", "AENOR", "AMN", "JIS", "ASTM", "ASME", "API", "IEEE", "NFPA"
        };

        public static void ConfigureDB(IConfiguration configuration)
        {
            using (SqlConnection db = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                BaseRepository.CreateTableIfNotExists<Norma>(db, "Norma", "normas_seed.json");
            }
        }

        private readonly IConfiguration _config;

        public NormaRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Norma> Get()
        {
            using (SqlConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return db.Query<Norma>("SELECT * FROM Norma");
            }
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index =>
            //{
            //    var organismo = OrganismoList[rng.Next(OrganismoList.Length)];
            //    return new Norma
            //    {
            //        Codigo = $"{organismo}{rng.Next(1000, 80000)}",
            //        Titulo = Summaries[rng.Next(Summaries.Length)],
            //        DataPublicacao = DateTime.Now.AddDays(index),
            //        Paginas = rng.Next(20, 55),
            //        Status = StatusList[rng.Next(StatusList.Length)],
            //        Organismo = organismo
            //    };
            //})
            //.ToArray();
        }
    }
}

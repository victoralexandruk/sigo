using SIGO.Domain.Normas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIGO.Normas.Tests.Mock
{
    class NormaMock
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

        public static IEnumerable<Norma> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index =>
            {
                var organismo = OrganismoList[rng.Next(OrganismoList.Length)];
                return new Norma
                {
                    Codigo = $"{organismo}{rng.Next(1000, 80000)}",
                    Titulo = Summaries[rng.Next(Summaries.Length)],
                    //DataPublicacao = DateTime.Now.AddDays(index),
                    Paginas = rng.Next(20, 55),
                    Status = StatusList[rng.Next(StatusList.Length)],
                    Organismo = organismo
                };
            })
            .ToArray();
        }
    }
}

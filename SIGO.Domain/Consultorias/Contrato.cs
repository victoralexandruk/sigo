using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Domain.Consultorias
{
    public class Contrato
    {
        [Key]
        public long Id { get; set; }

        [Column]
        public string Cnpj { get; set; }

        [Column]
        public string Tipo { get; set; }

        [Column]
        public DateTime? DataInicio { get; set; }

        [Column]
        public DateTime? DataTermino { get; set; }

        [Column]
        public string Area { get; set; }
        
        public Empresa Empresa { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Domain.Consultorias
{
    public class Consultoria
    {
        [Key]
        public long Id { get; set; }

        [Column]
        public string Nome { get; set; }

        [Column]
        public string Tipo { get; set; }

        [Column]
        public string Area { get; set; }
    }
}

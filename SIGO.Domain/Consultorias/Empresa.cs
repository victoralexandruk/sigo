using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Domain.Consultorias
{
    public class Empresa
    {
        [Key]
        public long Id { get; set; }

        [Column]
        public string Cnpj { get; set; }

        [Column]
        public string RazaoSocial { get; set; }

        [Column]
        public string NomeFantasia { get; set; }

        [Column]
        public string Situacao { get; set; }
    }
}

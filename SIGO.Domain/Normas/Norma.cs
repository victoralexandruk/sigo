﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Domain.Normas
{
    public class Norma
    {
        [Key]
        [Column]
        public string Codigo { get; set; }

        [Column]
        public string Titulo { get; set; }

        [Column]
        public string DataPublicacao { get; set; }

        [Column]
        public string Comite { get; set; }

        [Column]
        public int Paginas { get; set; }

        [Column]
        public string Status { get; set; }

        [Column]
        public string Idioma { get; set; }

        [Column]
        public string Organismo { get; set; }

        [Column]
        public string Objetivo { get; set; }

        [Column]
        public string CaminhoArquivo { get; set; }
    }
}
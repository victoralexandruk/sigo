using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGO.Domain.Normas
{
    public class AcaoPlanejada
    {
        [Key]
        public long Id { get; set; }

        [Column]
        public string CodigoNorma { get; set; }

        [Column]
        public string Descricao { get; set; }
    }
}

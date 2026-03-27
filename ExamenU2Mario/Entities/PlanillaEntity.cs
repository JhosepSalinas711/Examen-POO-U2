using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU2Mario.Entities
{
    [Table("Planillas")]
    public class PlanillaEntity
    {
        [Key]
        [StringLength(13)]
        [Column("id")]
        public int Id { get; set; }

        [Required()]
        [StringLength(40)]
        [Column("periodo")]
        public string Periodo { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

    }
}
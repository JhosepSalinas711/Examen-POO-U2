using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU2Mario.Entities
{
    [Table("Empleados")]
    public class EmpleadoEntity 
    {
        [Key]
        [StringLength(13)]
        [Column("id")]
        public int Id { get; set; }

        [Required()]
        [StringLength(40)]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required()]
        [StringLength(40)]
        [Column("apellido")]
        public string Apellido { get; set; }

        [Required()]
        [Column("documento")]
        public string Documento { get; set; }

        [Column("fecha_contratacion")]
        public DateTime FechaContratacion { get; set; }

        [Column("departamento")]
        public string Departamento { get; set; }

        [Column("puesto_trabajo")]
        public string PuestoTrabajo { get; set; }

        [Column("Salario_Base")]
        public decimal SalarioBase { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }


    }
}
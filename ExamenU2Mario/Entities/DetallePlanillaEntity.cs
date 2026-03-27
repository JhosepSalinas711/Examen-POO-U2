using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU2Mario.Entities
{
    [Table("DetallesPlanilla")]
    public class DetallePlanillaEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("planilla_id")]
        public int PlanillaId { get; set; }

        [Column("empleado_id")]
        public int EmpleadoId { get; set; }

        [Column("salario_base")]
        public decimal SalarioBase { get; set; }

        [Column("horas_extra")]
        public decimal HorasExtra { get; set; }

        [Column("monto_horas_extra")]
        public decimal MontoHorasExtra { get; set; }

        [Column("bonificaciones")]
        public decimal Bonificaciones { get; set; }

        [Column("deducciones")]
        public decimal Deducciones { get; set; }

        [Column("salario_neto")]
        public decimal SalarioNeto { get; set; }

        [Column("comentarios")]
        public string Comentarios { get; set; }

        public PlanillaEntity Planilla { get; set; }
        public EmpleadoEntity Empleado { get; set; }
    }
}
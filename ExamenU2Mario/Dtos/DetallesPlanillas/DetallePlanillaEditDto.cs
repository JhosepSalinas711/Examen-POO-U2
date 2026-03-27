using System.ComponentModel.DataAnnotations;

namespace ExamenU2Mario.Dtos.Detalles
{
    public class DetallePlanillaEditDto
    {
        [Range(0, double.MaxValue, ErrorMessage = "Debe ser positivo")]
        public decimal HorasExtra { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Debe ser positivo")]
        public decimal MontoHorasExtra { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Debe ser positivo")]
        public decimal Bonificaciones { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Debe ser positivo")]
        public decimal Deducciones { get; set; }

        public string Comentarios { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ExamenU2Mario.Dtos.Empleados
{
    public class EmpleadoCreateDto
    {
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Documento { get; set; }

        public DateTime FechaContratacion { get; set; }
        public string Departamento { get; set; }
        public string PuestoTrabajo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser positivo")]
        public decimal SalarioBase { get; set; }
    }
}
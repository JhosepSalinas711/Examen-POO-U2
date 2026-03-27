using System.ComponentModel.DataAnnotations;

namespace ExamenU2Mario.Dtos.Planillas
{
    public class PlanillaEditDto
    {
        [Required]
        public string Periodo { get; set; }

        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
    }
}
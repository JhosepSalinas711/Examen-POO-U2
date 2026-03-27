using System.ComponentModel.DataAnnotations;

namespace ExamenU2Mario.Dtos.Planillas
{
    public class PlanillaCreateDto
    {
        [Required]
        public string Periodo { get; set; }

        public DateTime FechaPago { get; set; }
    }
}
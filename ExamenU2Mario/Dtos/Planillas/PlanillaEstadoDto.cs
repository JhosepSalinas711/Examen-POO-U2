using System.ComponentModel.DataAnnotations;

namespace ExamenU2Mario.Dtos.Planillas
{
    public class PlanillaEstadoDto
    {
        [Required]
        public string Estado { get; set; }
    }
}
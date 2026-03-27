using ExamenU2Mario.Dtos.Planillas;
using ExamenU2Mario.Entities;

namespace ExamenU2Mario.Mappers
{
    public static class PlanillaMapper
    {
        public static PlanillaEntity ToEntity(PlanillaCreateDto dto)
        {
            return new PlanillaEntity
            {
                Periodo = dto.Periodo,
                FechaPago = dto.FechaPago,
                FechaCreacion = DateTime.Now,
                Estado = "Pendiente"
            };
        }

        public static PlanillaDto ToDto(PlanillaEntity entity)
        {
            return new PlanillaDto
            {
                Id = entity.Id,
                Periodo = entity.Periodo,
                FechaCreacion = entity.FechaCreacion,
                FechaPago = entity.FechaPago,
                Estado = entity.Estado
            };
        }
    }
}
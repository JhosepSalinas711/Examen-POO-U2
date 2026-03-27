using ExamenU2Mario.Dtos.Detalles;
using ExamenU2Mario.Entities;

namespace ExamenU2Mario.Mappers
{
    public static class DetallePlanillaMapper
    {
        public static DetallePlanillaEditDto ToDto(DetallePlanillaEntity entity)
        {
            return new DetallePlanillaEditDto
            {
                HorasExtra = entity.HorasExtra,
                MontoHorasExtra = entity.MontoHorasExtra,
                Bonificaciones = entity.Bonificaciones,
                Deducciones = entity.Deducciones,
                Comentarios = entity.Comentarios
            };
        }

        public static void UpdateEntity(DetallePlanillaEntity entity, DetallePlanillaEditDto dto)
        {
            entity.HorasExtra = dto.HorasExtra;
            entity.MontoHorasExtra = dto.MontoHorasExtra;
            entity.Bonificaciones = dto.Bonificaciones;
            entity.Deducciones = dto.Deducciones;
            entity.Comentarios = dto.Comentarios;

            entity.SalarioNeto = entity.SalarioBase 
                               + entity.MontoHorasExtra 
                               + entity.Bonificaciones 
                               - entity.Deducciones;
        }
    }
}
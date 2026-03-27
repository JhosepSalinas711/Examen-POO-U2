using ExamenU2Mario.Dtos.Empleados;
using ExamenU2Mario.Entities;

namespace ExamenU2Mario.Mappers
{
    public static class EmpleadoMapper
    {
        public static EmpleadoEntity EmpleadoCreateDtoToEntity(EmpleadoCreateDto dto)
        {
            return new EmpleadoEntity
            {

                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento,
                FechaContratacion = dto.FechaContratacion,
                Departamento = dto.Departamento,
                PuestoTrabajo = dto.PuestoTrabajo,
                SalarioBase = dto.SalarioBase,

            };
        }

        public static void UpdateEntity(EmpleadoEntity entity, EmpleadoEditDto dto)
        {
            entity.Nombre = dto.Nombre;
            entity.Apellido = dto.Apellido;
            entity.Documento = dto.Documento;
            entity.FechaContratacion = dto.FechaContratacion;
            entity.Departamento = dto.Departamento;
            entity.PuestoTrabajo = dto.PuestoTrabajo;
            entity.SalarioBase = dto.SalarioBase;
        }

        internal static object ToDto(EmpleadoEntity e)
        {
            throw new NotImplementedException();
        }
    }
}
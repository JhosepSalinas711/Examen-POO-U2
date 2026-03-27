using ExamenU2Mario.DataBase;
using ExamenU2Mario.Dtos.Detalles;
using ExamenU2Mario.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2Mario.Services
{
    public class DetallePlanillaService
    {
        private readonly AppDbContext _context;

        public DetallePlanillaService(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET TODOS
        public async Task<List<DetallePlanillaDto>> GetAll()
        {
            return await _context.Detalles
                .Select(d => new DetallePlanillaDto
                {
                    Id = d.Id,
                    EmpleadoId = d.EmpleadoId,
                    PlanillaId = d.PlanillaId,
                    SalarioNeto = d.SalarioNeto
                })
                .ToListAsync();
        }

        // 🔹 GET POR ID
        public async Task<DetallePlanillaDto> GetById(int id)
        {
            var d = await _context.Detalles.FindAsync(id);

            if (d == null) return null;

            return new DetallePlanillaDto
            {
                Id = d.Id,
                EmpleadoId = d.EmpleadoId,
                PlanillaId = d.PlanillaId,
                SalarioNeto = d.SalarioNeto
            };
        }

        // 🔹 GET POR PLANILLA
        public async Task<List<DetallePlanillaDto>> GetByPlanilla(int planillaId)
        {
            return await _context.Detalles
                .Where(d => d.PlanillaId == planillaId)
                .Select(d => new DetallePlanillaDto
                {
                    Id = d.Id,
                    EmpleadoId = d.EmpleadoId,
                    PlanillaId = d.PlanillaId,
                    SalarioNeto = d.SalarioNeto
                })
                .ToListAsync();
        }

        // 🔹 GET POR EMPLEADO
        public async Task<List<DetallePlanillaDto>> GetByEmpleado(int empleadoId)
        {
            return await _context.Detalles
                .Where(d => d.EmpleadoId == empleadoId)
                .Select(d => new DetallePlanillaDto
                {
                    Id = d.Id,
                    EmpleadoId = d.EmpleadoId,
                    PlanillaId = d.PlanillaId,
                    SalarioNeto = d.SalarioNeto
                })
                .ToListAsync();
        }

        // 🔹 CREATE
        public async Task<DetallePlanillaDto> Create(DetallePlanillaCreateDto dto)
        {
            var empleado = await _context.Empleados.FindAsync(dto.EmpleadoId);
            var planilla = await _context.Planillas.FindAsync(dto.PlanillaId);

            if (empleado == null || planilla == null)
                throw new Exception("Empleado o Planilla no existen");

            if (dto.HorasExtra < 0 || dto.Bonificaciones < 0 || dto.Deducciones < 0)
                throw new Exception("Valores inválidos");

            decimal salarioNeto = empleado.SalarioBase
                + dto.HorasExtra
                + dto.Bonificaciones
                - dto.Deducciones;

            var detalle = new DetallePlanillaEntity
            {
                EmpleadoId = dto.EmpleadoId,
                PlanillaId = dto.PlanillaId,
                SalarioBase = empleado.SalarioBase,
                HorasExtra = dto.HorasExtra,
                Bonificaciones = dto.Bonificaciones,
                Deducciones = dto.Deducciones,
                SalarioNeto = salarioNeto
            };

            _context.Detalles.Add(detalle);
            await _context.SaveChangesAsync();

            return new DetallePlanillaDto
            {
                Id = detalle.Id,
                EmpleadoId = detalle.EmpleadoId,
                PlanillaId = detalle.PlanillaId,
                SalarioNeto = detalle.SalarioNeto
            };
        }

        // 🔹 UPDATE
        public async Task<bool> Update(int id, DetallePlanillaCreateDto dto)
        {
            var detalle = await _context.Detalles.FindAsync(id);
            if (detalle == null) return false;

            if (dto.HorasExtra < 0 || dto.Bonificaciones < 0 || dto.Deducciones < 0)
                throw new Exception("Valores inválidos");

            decimal salarioNeto = detalle.SalarioBase
                + dto.HorasExtra
                + dto.Bonificaciones
                - dto.Deducciones;

            detalle.HorasExtra = dto.HorasExtra;
            detalle.Bonificaciones = dto.Bonificaciones;
            detalle.Deducciones = dto.Deducciones;
            detalle.SalarioNeto = salarioNeto;

            await _context.SaveChangesAsync();
            return true;
        }

        // 🔹 DELETE
        public async Task<bool> Delete(int id)
        {
            var detalle = await _context.Detalles.FindAsync(id);

            if (detalle == null) return false;

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
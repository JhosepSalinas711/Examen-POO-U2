using ExamenU2Mario.DataBase;
using ExamenU2Mario.Entities;
using ExamenU2Mario.Dtos.Planillas;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2Mario.Services
{
    public class PlanillaService
    {
        private readonly AppDbContext _context;

        public PlanillaService(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET TODOS
        public async Task<List<PlanillaDto>> GetAll()
        {
            return await _context.Planillas
                .Select(p => new PlanillaDto
                {
                    Id = p.Id,
                    FechaPago = p.FechaPago,
                    Periodo = p.Periodo,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        // 🔹 GET POR ID
        public async Task<PlanillaDto> GetById(int id)
        {
            var p = await _context.Planillas.FindAsync(id);

            if (p == null) return null;

            return new PlanillaDto
            {
                Id = p.Id,
                FechaPago = p.FechaPago,
                Periodo = p.Periodo,
                Estado = p.Estado
            };
        }

        // 🔹 GET POR PERIODO
        public async Task<List<PlanillaDto>> GetByPeriodo(string periodo)
        {
            return await _context.Planillas
                .Where(p => p.Periodo == periodo)
                .Select(p => new PlanillaDto
                {
                    Id = p.Id,
                    FechaPago = p.FechaPago,
                    Periodo = p.Periodo,
                    Estado = p.Estado
                })
                .ToListAsync();
        }

        // 🔹 CREATE
        public async Task<PlanillaDto> Create(PlanillaCreateDto dto)
        {
            var existe = await _context.Planillas
                .AnyAsync(p => p.Periodo == dto.Periodo);

            if (existe)
                throw new Exception("Ya existe una planilla para ese periodo");

            var planilla = new PlanillaEntity
            {
                FechaPago = dto.FechaPago,
                Periodo = dto.Periodo,
                Estado = "Pendiente"
            };

            _context.Planillas.Add(planilla);
            await _context.SaveChangesAsync();

            return new PlanillaDto
            {
                Id = planilla.Id,
                FechaPago = planilla.FechaPago,
                Periodo = planilla.Periodo,
                Estado = planilla.Estado
            };
        }

        // 🔹 UPDATE
        public async Task<bool> Update(int id, PlanillaCreateDto dto)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla == null) return false;

            planilla.FechaPago = dto.FechaPago;
            planilla.Periodo = dto.Periodo;

            await _context.SaveChangesAsync();
            return true;
        }

        // 🔹 UPDATE ESTADO
        public async Task<bool> UpdateEstado(int id, string estado)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla == null) return false;

            planilla.Estado = estado;
            await _context.SaveChangesAsync();
            return true;
        }

        // 🔹 DELETE (con validación)
        public async Task<bool> Delete(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla == null) return false;

            if (planilla.Estado == "Pagada")
                throw new Exception("No se puede eliminar una planilla pagada");

            _context.Planillas.Remove(planilla);
            await _context.SaveChangesAsync();
            return true;
        }

        // 🔥 GENERAR PLANILLA AUTOMÁTICA
        public async Task GenerarPlanilla(string periodo)
        {
            var existe = await _context.Planillas
                .AnyAsync(p => p.Periodo == periodo);

            if (existe)
                throw new Exception("Ya existe planilla en ese periodo");

            var empleados = await _context.Empleados
                .Where(e => e.Activo)
                .ToListAsync();

            var planilla = new PlanillaEntity
            {
                FechaCreacion = DateTime.Now,
                Periodo = periodo,
                Estado = "Pendiente"
            };

            _context.Planillas.Add(planilla);
            await _context.SaveChangesAsync();

            foreach (var emp in empleados)
            {
                var detalle = new DetallePlanillaEntity
                {
                    EmpleadoId = emp.Id,
                    PlanillaId = planilla.Id,
                    SalarioBase = emp.SalarioBase,
                    HorasExtra = 0,
                    Bonificaciones = 0,
                    Deducciones = 0,
                    SalarioNeto = emp.SalarioBase
                };

                _context.Detalles.Add(detalle);
            }

            await _context.SaveChangesAsync();
        }
    }
}
using ExamenU2Mario.DataBase;
using ExamenU2Mario.Dtos.Empleados;
using ExamenU2Mario.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2Mario.Services
{
    public class EmpleadoService
    {
        private readonly AppDbContext _context;

        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmpleadoDto>> GetAll()
        {
            return await _context.Empleados
                .Select(e => new EmpleadoDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    SalarioBase = e.SalarioBase,
                    Activo = e.Activo
                }).ToListAsync();
        }

        public async Task<EmpleadoDto> GetById(int id)
        {
            var e = await _context.Empleados.FindAsync(id);
            if (e == null) return null;

            return new EmpleadoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                SalarioBase = e.SalarioBase,
                Activo = e.Activo
            };
        }

        public async Task<List<EmpleadoDto>> GetActivos()
        {
            return await _context.Empleados
                .Where(e => e.Activo)
                .Select(e => new EmpleadoDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    SalarioBase = e.SalarioBase,
                    Activo = e.Activo
                }).ToListAsync();
        }

        public async Task<EmpleadoDto> Create(EmpleadoCreateDto dto)
        {
            if (dto.SalarioBase < 0)
                throw new Exception("Salario inválido");

            var existe = await _context.Empleados
                .AnyAsync(e => e.Documento == dto.Documento);

            if (existe)
                throw new Exception("Documento ya existe");

            var empleado = new EmpleadoEntity
            {
                Nombre = dto.Nombre,
                SalarioBase = dto.SalarioBase,
                Documento = dto.Documento,
                Activo = true
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return new EmpleadoDto
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                SalarioBase = empleado.SalarioBase,
                Activo = empleado.Activo
            };
        }

        public async Task<bool> Update(int id, EmpleadoCreateDto dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            if (dto.SalarioBase < 0)
                throw new Exception("Salario inválido");

            empleado.Nombre = dto.Nombre;
            empleado.SalarioBase = dto.SalarioBase;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            empleado.Activo = false; // baja lógica
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
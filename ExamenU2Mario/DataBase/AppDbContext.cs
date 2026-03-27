using ExamenU2Mario.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2Mario.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<EmpleadoEntity> Empleados { get; set; }
        public DbSet<PlanillaEntity> Planillas { get; set; }
        public DbSet<DetallePlanillaEntity> Detalles { get; set; }
    }
}
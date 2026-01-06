using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Medicamento> Medicamentos { get; set; } = null!;

        // Borramos el OnModelCreating para que no busque relaciones
    }
}
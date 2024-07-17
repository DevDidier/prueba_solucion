using Microsoft.EntityFrameworkCore;
using prueba_solucion.Models.Entities.Clientes;

namespace prueba_solucion.Context
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<ClientesEntity> ? Clientes { get; set; }//añadimos la identidad al contexto de db

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

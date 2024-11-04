using ApiDrinkInTheHouse.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options)
            : base(options) { } 
        

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<VentaCliente> VentasCliente { get; set; }
    }
}

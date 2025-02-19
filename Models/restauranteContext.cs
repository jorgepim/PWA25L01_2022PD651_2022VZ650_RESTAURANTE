using Microsoft.EntityFrameworkCore;

namespace L01_2022PD651_2022VZ650.Models
{
    public class restauranteContext : DbContext
    {
        public restauranteContext(DbContextOptions<restauranteContext> options) : base(options)
        {
        }
        public DbSet<platos> platos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Motoristas> Motoristas { get; set; }
    }

}

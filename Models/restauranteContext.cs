using Microsoft.EntityFrameworkCore;

namespace L01_2022PD651_2022VZ650.Models
{
    public class restauranteContext : DbContext
    {
        public restauranteContext(DbContextOptions<restauranteContext> options) : base(options)
        {
        }
<<<<<<< HEAD
        public DbSet<platos> platos { get; set; }

=======
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Motoristas> Motoristas { get; set; }
>>>>>>> 90cd49d4094c21d83489bb7098481edaab7d3106
    }

}

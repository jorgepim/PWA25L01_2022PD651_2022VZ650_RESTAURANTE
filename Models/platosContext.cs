using Microsoft.EntityFrameworkCore;

namespace L01_2022PD651_2022VZ650.Models
{
    public class platosContext: DbContext
    {
        public platosContext(DbContextOptions<platosContext> options) : base(options)
        {
        }

        public DbSet<platos> platos { get; set; }
    }
}

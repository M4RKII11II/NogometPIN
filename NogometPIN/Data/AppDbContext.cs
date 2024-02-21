using Microsoft.EntityFrameworkCore;

namespace NogometPIN.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options) { }
        public DbSet<Player> Players { get; set;}
        public DbSet<Position> Positions { get; set;}
    }
}

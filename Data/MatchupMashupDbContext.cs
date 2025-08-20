using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MatchupMashup.Data
{
    public class MatchupMashupDbContext : DbContext
    {
        public MatchupMashupDbContext(DbContextOptions<MatchupMashupDbContext> options)
            : base(options)
        {
        }

        // Example DbSet for NFL Teams
        public DbSet<MatchupMashup.Models.Team> Teams { get; set; }

        // Example DbSet for Players
        public DbSet<MatchupMashup.Models.Player> Players { get; set; }
    }

    public class MatchupMashupDbContextFactory : IDesignTimeDbContextFactory<MatchupMashupDbContext>
    {
        public MatchupMashupDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MatchupMashupDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=matchupmashup;Username=postgres;Password=98520Jwd");

            return new MatchupMashupDbContext(optionsBuilder.Options);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MatchupMashup.Models;

namespace MatchupMashup.Data
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(MashupMatchupDbContext context)
        {
            // Check if data already exists to avoid duplicate seeding
            if (await context.Teams.AnyAsync())
            {
                Console.WriteLine("Database already contains data. Skipping seeding.");
                return;
            }

            Console.WriteLine("Starting database seeding...");

            // Seed all 32 NFL teams
            var teams = CreateAllNFLTeams();
            await context.Teams.AddRangeAsync(teams);
            await context.SaveChangesAsync();

            // Seed players for each team
            foreach (var team in teams)
            {
                var players = CreateTeamPlayers(team);
                await context.Players.AddRangeAsync(players);
            }
            await context.SaveChangesAsync();

            Console.WriteLine($"Seeded {teams.Count} teams and {context.Players.Count()} players");
        }

        private static List<Team> CreateAllNFLTeams()
        {
            return new List<Team>
            {
            };
        }    
    }
}
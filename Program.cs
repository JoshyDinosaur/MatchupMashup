using System;
using System.Reflection.Metadata.Ecma335;
using MatchupMashup.Models;
using MatchupMashup.Services;
using MatchupMashup.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace MatchupMashup
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Inject EF DbContext directly into your console program so you can query
            // or post to the database
            var options = new DbContextOptionsBuilder<MatchupMashupDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=matchupmashup;Username=postgres;Password=98520Jwd")
            .Options;

            using var context = new MatchupMashupDbContext(options);

            // Example: add a team
            var team = new Team("Eagles", "PHI", "NFC", "EAST", "Lincoln Financial Field", "Philadelphia", 15, 2, 28.1, 19.2);
            context.Teams.Add(team);
            context.SaveChanges();

            Console.WriteLine("Team saved to PostgreSQL!");

            // Create the service
            var matchupService = new MatchupService();

            var nflDataService = new NFLDataService(
                new HttpClient(),
                new ConsoleLogger(), //Simple logger for console app
                new NFLDataConfig()
            );

            // Test the service
            Console.WriteLine("Testing NFL Data Service...");
            var teams = await nflDataService.FetchAllTeamsAsync();
            Console.WriteLine($"Fetched {teams.Count} teams from Pro Football Reference");


            // Create some example teams
            var teamA = new Team("Eagles", "PHI", "NFC", "East", "Lincoln Financial Field", "Philadelphia", 15, 2, 28.1, 19.2);
            var teamB = new Team("Broncos", "DEN", "AFC", "West", "Empower Field @ Mile High", "Denver", 10, 7, 24.5, 17.6);

            var Player1 = new Player("Jalen Hurts", "QB", 1, teamA);
            var Player2 = new Player("Bo Nix", "QB", 10, teamB);

            teamA.AddPlayer(Player1);
            teamB.AddPlayer(Player2);

            // Create the matchup
            var matchup = matchupService.CreateMatchup(teamA, teamB, new DateTime(2025, 11, 10), "Empower Field @ Mile High");

            // Testing Area
            Console.WriteLine($"{teamA.Name} roster:");
            foreach (var player in teamA.Players)
            {
                Console.WriteLine($"#{player.Number} {player.Name} - {player.Position}");
            }
        }
    }
}

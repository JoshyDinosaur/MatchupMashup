using System;
using System.Reflection.Metadata.Ecma335;
using MatchupMashup.Models;
using MatchupMashup.Services;

namespace MatchupMashup
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the service
            var matchupService = new MatchupService();

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

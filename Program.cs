using System;
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
            var teamA = new Team("Eagles", "PHI", "NFC", "East", 15, 2);
            var teamB = new Team("Broncos", "DEN", "AFC", "West", 10, 7);

            // Create the matchup
            var matchup = matchupService.CreateMatchup(teamA, teamB);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Matchup created: {matchup.TeamA.Name} vs {matchup.TeamB.Name}");

            // Record result (for now, we'll hardcode Broncos as winner)
            matchupService.RecordResult(matchup, teamB);
            if (matchup.Winner != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"Winner recorded: {matchup.Winner.Name}");
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                throw new ArgumentException("Winner must be non-null.");
            }
        }
    }
}

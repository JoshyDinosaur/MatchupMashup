using System;
using MatchupMashup.Models;
using MatchupMashup.Services;

namespace MatchupMashup
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamService = new TeamService();

            Team broncos = teamService.CreateTeam("Denver Broncos", "DEN", "AFC", "West", 10, 7);
            Team bengals = teamService.CreateTeam("Cincinatti Bengals", "CIN", "AFC", "North", 9, 8);

            // Display team info
            Console.WriteLine("===Team Info===");
            teamService.DisplayTeamInfo(broncos);
            Console.WriteLine("===Team Info===");
            teamService.DisplayTeamInfo(bengals);
            

            // Wait for user before closing
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

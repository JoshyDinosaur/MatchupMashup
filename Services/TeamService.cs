using System;
using MatchupMashup.Models;

namespace MatchupMashup.Services
{
    public class TeamService
    {
        public void DisplayTeamInfo(Team team)
        {
            Console.WriteLine($"Team: {team.Name}");
            Console.WriteLine($"Wins: {team.Wins}, Losses: {team.Losses}");
            Console.WriteLine($"Win Rate: {team.WinRate:P2}");
        }

        public Team CreateTeam(string name, string abbreviation, string conference, string division, int wins, int losses)
        {
            return new Team
            (
                name,abbreviation,conference,division,wins,losses
            );
            
        }
    }
}
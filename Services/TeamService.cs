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

        public Team CreateTeam(string name, string abbreviation, string conference, string division, string stadium, string city,
        int wins, int losses, double avgpointsscored,double avgpointsallowed)
        {
            return new Team
            {
                Name = name,
                Abbreviation = abbreviation,
                Conference = conference,
                Division = division,
                Stadium = stadium,
                City = city,
                Wins = wins,
                Losses = losses,
                AveragePointsScored = avgpointsscored,
                AveragePointsAllowed = avgpointsallowed
            };
            
        }
    }
}
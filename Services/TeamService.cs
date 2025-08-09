using MatchupMashup.Models;

namespace MatchupMashup.Services
{
    public class TeamService
    {
        public void DisplayTeamInfo(Team team)
        {
            Console.WriteLine($"Team: {team.Name}");
            Console.WriteLine($"Wins: {team.Wins}, Losses: {team.Losses}");
            Console.WriteLine($"Win%: {team.WinPercentage:P2}");
        }

        public Team CreateTeam(string name, int wins, int losses)
        {
            return new Team
            {
                Name = name,
                Wins = wins,
                Losses = losses
            };
        }

    }
}
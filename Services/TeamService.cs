using MatchupMashup.Models;

namespace MatchupMashup.Services
{
    public class TeamService
    {
        public void DisplayTeamInfo(Team team)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public Team CreateTeam(string name, string abbreviation, string conference, string division, int wins, int losses)
        {
            return new Team
            {
                Name = name,
                Abbreviation = abbreviation,
                Conference = conference,
                Division = division,
                Wins = wins,
                Losses = losses
            };
            
        }
    }
}
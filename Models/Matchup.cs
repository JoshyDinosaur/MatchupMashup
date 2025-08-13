
namespace MatchupMashup.Models
{
    public class Matchup
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public Team? Winner { get; set; }

        public Matchup(Team teamA, Team teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
            Winner = null;
        }
    }
}
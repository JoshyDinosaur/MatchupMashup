
namespace MatchupMashup.Models
{
    public class Matchup
    {
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public Team? Winner { get; set; }
        public int? TeamAScore { get; set; }
        public int? TeamBScore { get; set; }
        public DateTime GameDate { get; set; }
        public string Location { get; set; } // Stadium or City
        public string Status { get; set; } // Scheduled, In Progress, Completed

        public Matchup(Team teamA, Team teamB, DateTime date, string location)
        {
            TeamA = teamA;
            TeamB = teamB;
            Winner = null;
            GameDate = date;
            Location = location;
            Status = "Scheduled";
        }

        public override string ToString()
        {
            return $"{TeamA.Name} vs {TeamB.Name} at {Location} on {GameDate:MMM dd, yyyy} - Status: {Status}";
        }
    }
}

namespace MatchupMashup.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }

        // Basic optional stats
        public int Touchdowns { get; set; } = 0;
        public int TotalYards { get; set; } = 0;

        // Navigation property back to Team
        public Team Team { get; set; }

        public Player(string name, string position, int number, Team team)
        {
            Name = name;
            Position = position;
            Number = number;
            Team = team;
        }
    }
}

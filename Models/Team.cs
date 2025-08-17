using System.ComponentModel;
using System.Dynamic;

namespace MatchupMashup.Models
{
    public class Team // Class definition
    { // __init__ method (getters and setters)
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string? Stadium { get; set; }
        public string? City { get; set; }
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public double? AveragePointsScored { get; set; }
        public double? AveragePointsAllowed { get; set; }
        public int? TotalGames { get; set; }
        public double? WinRate
        {
            get
            {
                int totalGames = Wins + Losses;
                return totalGames > 0 ? (double)Wins / totalGames : 0;
            }
        }
        public List<Player> Players { get; set; } = new List<Player>();
        public void AddPlayer(Player player)
        {
            player.Team = this;
            Players.Add(player);
        }

        public Team() { }

        public Team(string name, string abbreviation, string conference, string division, string stadium,
        string city, int wins, int losses, double averagepointsscored, double averagepointsallowed)
        {
            Name = name;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            Stadium = stadium;
            City = city;
            Wins = wins;
            Losses = losses;
            AveragePointsScored = averagepointsscored;
            AveragePointsAllowed = averagepointsallowed;
            TotalGames = wins + losses;
        } 
        // Team Class Methods below here

        public void RecordWin()
        {
            Wins++;
        }
        public void RecordLoss()
        {
            Losses++;
        }

    }
}

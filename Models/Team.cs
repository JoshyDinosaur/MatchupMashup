using System.ComponentModel;

namespace MatchupMashup.Models
{
    public class Team // Class definition
    { // __init__ method (getters and setters)
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double AveragePointsScored { get; set; }
        public double AveragePointsAllowed { get; set; }
        public int TotalGames { get; set; }
        public double WinRate
        {
            get
            {
                int totalGames = Wins + Losses;
                return totalGames > 0 ? (double)Wins / totalGames : 0;
            }
        }


        public Team(string name, string abreviation, string conference, string division, int wins = 0, int losses = 0,
        double avgPointsScored = 0, double avgPointsAllowed = 0)
        {
            Name = name;
            Abreviation = abreviation;
            Conference = conference;
            Division = division;
            Wins = wins;
            AveragePointsScored = avgPointsScored;
            AveragePointsAllowed = avgPointsAllowed;
            Losses = losses;
            TotalGames = wins + losses;

        }

        
    }
}

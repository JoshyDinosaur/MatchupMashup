namespace MatchupMashup.Models
{
    public class Team
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public double WinPercentage
        {
            get
            {
                int totalGames = Wins + Losses;
                return totalGames == 0 ? 0 : (double)Wins / totalGames;
            }
        }

        public Team(string name, string abbreviation, string conference, string division)
        {
            Name = name;
            Abbreviation = abbreviation;
            Conference = conference;
            Division = division;
            Wins = 0;
            Losses = 0;
        }

        public void RecordWin() => Wins++;
        public void RecordLoss() => Losses++;
    }
}
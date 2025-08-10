
using MatchupMashup.Models;

   namespace MatchupMashup.Services
{
    public class MatchupService
    {
        // Predict winner using simple rule for now    
        public Team PredictWinner(Matchup matchup)
        {
            // Temporary logic: pick the team with higher WinPercentage
            // If equal, default to TeamA
            if (matchup.TeamA.WinRate > matchup.TeamB.WinRate)
                return matchup.TeamA;
            else if (matchup.TeamB.WinRate > matchup.TeamA.WinRate)
                return matchup.TeamB;
            else
                return matchup.TeamA;
        }
        public void RecordWinner(Matchup matchup, Team winner)
        {
            matchup.Winner = winner;
        }
    }
}

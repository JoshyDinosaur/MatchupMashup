
using MatchupMashup.Models;

   namespace MatchupMashup.Services
{
    public class MatchupService
    {
        private readonly List<Matchup> _matchups = new();

        // Create a matchup and store it
        public Matchup CreateMatchup(Team teamA, Team teamB, DateTime gamedate, string location)
        {
            var matchup = new Matchup(teamA, teamB, gamedate, location);
            _matchups.Add(matchup);
            Console.WriteLine($"Matchup created: {matchup}");
            return matchup;
        }

        // Record the result of a matchup
        public void RecordResult(Matchup matchup, Team winner, int teamAScore, int teamBScore)
        {
            if (winner != matchup.TeamA && winner != matchup.TeamB)
            {
                throw new ArgumentException("Winner must be one of the teams in the matchup.");
            }
            matchup.Winner = winner;
            matchup.TeamAScore = teamAScore;
            matchup.TeamBScore = teamBScore;
            matchup.Status = "Completed";
            Console.WriteLine($"Winner recorded: {winner.Name} with score {teamAScore} - {teamBScore}");


        }

        public List<Matchup> GetAllMactchups()
        {
            return _matchups;
        }
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
    }
}


namespace MatchupMashup.Services
{
    public class NFLDataConfig
    {
        public string BaseUrl { get; set; } = "https://www.pro-football-reference.com";
        public int RequestDelayMs { get; set; } = 1000;
        public int MaxRetries { get; set; } = 3;
        public string UserAgent { get; set; } = "MatchupMashup/1.0 (Educational Project)";
        public int TimeoutSeconds { get; set; } = 30;
    }
}
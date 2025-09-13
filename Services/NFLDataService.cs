
using System.Net.Http;
using Microsoft.Extensions.Logging;
using MatchupMashup.Models;

namespace MatchupMashup.Services
{
    public class NFLDataService : INFLDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NFLDataService> _logger;
        private readonly NFLDataConfig _config;

        public NFLDataService(HttpClient httpClient, ILogger<NFLDataService> logger, NFLDataConfig config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _config = config;

            // Set up HTTP client defaults
            _httpClient.DefaultRequestHeaders.Add("User-Agent", _config.UserAgent);
        }

        public async Task<List<Teams>> FetchAllTeamsAsync()
        {
            _logger.LogInformation("Starting to fetch all NFL teams...");
            try
            {
                var teams = new List<Team>();
                var teamAbbreviations = GetAllTeamAbbreviations();

                foreach (var abbreviation in teamAbbreviations)
                {
                    var team = await FetchTeamsAsync(abbreviation);
                    if (team != null)
                    {
                        teams.Add(team);
                        _logger.LogInformation($"Fetched team: {team.Name}");
                    }

                    // Respect rate limits
                    await Task.Delay(_config.RequestDelayMs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all teams");
                throw;
            }
        }

        public async Task<List<Teams>> FetchTeamsAsync()
        {
            try
            {
                var url = $"{_config.BaseUrl}/teams/{teamAbbreviation.ToUpper()}/";
                var html = await FetchHtmlAsync(url);

                if (string.IsNullOrEmpty(html))
                {
                    _logger.LogWarning($"No HTML content received for team {teamAbbreviation}");
                    return null;
                }

                // Parse team data from HTML
                var team = ParseTeamFromHtml(html, teamAbbreviation);
                return team;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching team {teamAbbreviation}");
                return null;
            }
        }

        public async Task<List<Player>> FetchTeamPlayersAsync(string teamAbbreviation)
        {
            // We'll implement this after exploring the HTML structure
            throw new NotImplementedExemption("Player fetching will be implemented after HTML exploration");
        }

        public async Task<List<PlayerStats>> FetchPlayersAsync(string playerId)
        {
            // We'll implement this after exploring the HTML structure
            throw new NotImplementedExemption("Player fetching will be implemented after HTML exploration");
        }

        public async Task<List<GameResult>> FetchRecentGamesAsync()
        {
            // We'll implement this after exploring the HTML structure
            throw new NotImplementedExemption("Game results fetching will be implemented after HTML exploration");
        }

        private async Task<string> FetchHtmlAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"HTTP error fetching {url}");
                return null;
            }
        }

        private Team ParseTeamFromHtml(string html, string abbreviation)
        {
            // Placeholder - we'll implement this after exploring the HTML structure
            _logger.LogInformation($"Parsing HTML for team {abbreviation} (length: {html?.Length ?? 0})");

            // For now, return a basic team structure
            return new Team
            {
                Name = $"Team {abbreviation}",
                Abbreviation = abbreviation,
                Conference = "Unknown",
                Division = "Unknown",
                Stadium = "Unknown",
                City = "Unknown"
            };
        }

        private List<string> GetAllTeamAbbreviations()
        {
            // ALL 32 NFL team abbreviations
            return new List<string>
            {
                // NFC Teams
                "DAL",
                "PHI",
                "WAS",
                "NYG", // East
                "MIN",
                "DET",
                "GB",
                "CHI", // North
                "TB",
                "ATL",
                "CAR",
                "NO", // South
                "LAR",
                "ARI",
                "SEA",
                "SF", // West

                // AFC Teams
                "NE",
                "NYJ",
                "MIA",
                "BUF", // East
                "BAL",
                "CIN",
                "CLE",
                "PIT", // North
                "JAX",
                "TEN",
                "HOU",
                "IND", // South
                "DEN",
                "KC",
                "LAC",
                "LV", // West
            };
        }

    }
}
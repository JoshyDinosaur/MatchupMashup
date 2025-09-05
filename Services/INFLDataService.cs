public interface INFLDataService
{
    Task<List<Team>> FetchAllTeamsAsync();
    Task<List<Player>> FetchTeamPlayersAsync(string teamAbbreviation);
    Task<Team> FetchTeamAsync(string teamAbbreviation);
    Task<List<PlayerStats>> FetchPlayerStatsAsync(string playerID);
    Task<List<GameResult>> FetchRecentGamesAsync();

}
public class NFLDataService : INFLDataService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NFLDataService> _logger;
    private readonly RateLimiter _rateLimiter;

    // Implementation methods...
}
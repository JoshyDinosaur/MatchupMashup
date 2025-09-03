
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

        public NFLDataService(HttpClient httpClient, ILogger<NFLDataService> ilogger, NFLDataConfig config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _config = config;

            // Set up HTTP client defaults
            _httpClient.DefaultRequestHeaders.Add("User-Agent", _config.UserAgent);
        }
    }
}
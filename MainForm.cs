using System;
using System.Windows.Forms;
using MatchupMashup.Models;
using MatchupMashup.Services;
using MatchupMashup.Data;
using Microsoft.EntityFrameworkCore;

namespace MatchupMashup
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// This is your current form clast that defines your form's structure.
        /// </summary>

        public MainForm()
        {
            InitializeComponent(); // This sets up all UI controls
            InitializeServices(); // Your database/services setup
            LoadTeams();
        }

        private void InitializeServices()
        {
            // Database Setup
            // Inject EF DbContext directly into your console program so you can query
            // or post to the database
            var options = new DbContextOptionsBuilder<MatchupMashupDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=matchupmashup;Username=postgres;Password=98520Jwd")
            .Options;

            _context = new MatchupMashupDbContext(options);

            // Service Initialization
            _nflDataService = new NFLDataService(
                new HttpClient(),
                new ConsoleLogger(), //Simple logger for console app
                new NFLDataConfig()
            );

            _matchupService = new MatchupService();
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            // Example: add a team
            var team = new Team("Eagles", "PHI", "NFC", "EAST", "Lincoln Financial Field", "Philadelphia", 15, 2, 28.1, 19.2);
            context.Teams.Add(team);
            context.SaveChanges();

            MessageBox.Show("Team saved to PostgreSQL!");
            LoadTeams(); // Refresh the DataGridView
        }

        private async void fetchNFLDataButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Testing NFL Data Service...");
            var teams = await nflDataService.FetchAllTeamsAsync();
            MessageBox.Show($"Fetched {teams.Count} teams from Pro Football Reference");
        }

        private void CreateMatchupButton_Click(object sender, EventArgs e)
        {
            var teamA = new Team("Eagles", "PHI", "NFC", "East", "Lincoln Financial Field", "Philadelphia", 15, 2, 28.1, 19.2);
            var teamB = new Team("Broncos", "DEN", "AFC", "West", "Empower Field @ Mile High", "Denver", 10, 7, 24.5, 17.6);

            var matchup = matchupService.CreateMatchup(teamA, teamB, new DateTime(2025, 11, 10), "Empower Field @ Mile High");
            MessageBox.Show($"Created matchup: {matchup}");
        }
    }
}
var builder = WebAppliction.CreateBuilder(args);

// Add services to DI container
builder.Services.AddDbContext<MatchupMashupDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IMatchupService, MatchupService>();
builder.Services.AddScoped<INFLDataService, NFLDataService>();

// Add HTTP client for external APIs
builder.Services.AddHttpClient<INFLDataService, NFLDataService>();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add health checks
builder.Services.AddHealthChecks()
    .AddDbContext<MatchupMashupDbContext>();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

// Define API endpoints using minimal APIs
app.MapGet("/api/teams", async (ITeamService teamService) =>
    await teamService.GetAllTeamsAsync());

app.MapPost("/api/teams", async (CreateTeamRequest request, ITeamService teamService) =>
    await teamService.CreateTeamAsync(request));

app.MapGet("/api/matchups", async (IMatchupService matchupService) =>
    await matchupService.GetAllMatchupsAsync());

app.Run();

// Start at MatchupMashup Sr. Assistant Chat @ "Lets recreate/update..." and Step 2 of phase one
// Plan to go to the ProFootballRefence endpoint setup as soon at phase 1-4 on modern app setup complete
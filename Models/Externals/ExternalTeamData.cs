public class ExternalTeamData
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Conference { get; set; }
    public string Division { get; set; }
    public string Stadium { get; set; }
    public string City { get; set; }
    public string LogoUrl { get; set; }
    public List<ExternalPlayerData> Players { get; set; }
}
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ExportDto;

public class ExportGamesByGenresDto
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("Genre")]
    public string Genre { get; set; }

    [JsonProperty("Games")]
    public ExportGameDto[] Games { get; set; }

    [JsonProperty("TotalPlayers")]
    public int TotalPlayers { get; set; }
}

public class ExportGameDto
{
    [JsonProperty("Id")]
    public int Id { get; set; }

    [JsonProperty("Title")]
    public string Title { get; set; }

    [JsonProperty("Developer")]
    public string DeveloperName { get; set; }

    [JsonProperty("Tags")]
    public string Tags { get; set; }

    [JsonProperty("Players")]
    public int PlayersCount { get; set; }
}
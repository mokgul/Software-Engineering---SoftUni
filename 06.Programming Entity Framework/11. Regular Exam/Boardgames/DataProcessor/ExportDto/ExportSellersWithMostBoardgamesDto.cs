namespace Boardgames.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class ExportSellersWithMostBoardgamesDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Website")]
    public string Website { get; set; }

    [JsonProperty("Boardgames")]
    public ExportBoardgameDto[] Boardgames { get; set; }

}

public class ExportBoardgameDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Rating")]
    public double Rating { get; set; }

    [JsonProperty("Mechanics")]
    public string Mechanics { get; set; }

    [JsonProperty("Category")]
    public string Category { get; set; }

}
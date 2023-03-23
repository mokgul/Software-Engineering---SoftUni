using Newtonsoft.Json;

namespace Footballers.DataProcessor.ExportDto;

public class ExportTeamsWithMostFootballersDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Footballers")]
    public ExportFootballerDto[] Footballers { get; set; }
}

public class ExportFootballerDto
{
    [JsonProperty("FootballerName")]
    public string FootballerName { get; set; }

    [JsonProperty("ContractStartDate")]
    public string ContractStartDate { get; set; }

    [JsonProperty("ContractEndDate")]
    public string ContractEndDate { get; set; }

    [JsonProperty("BestSkillType")]
    public string BestSkill { get; set; }

    [JsonProperty("PositionType")]
    public string Position { get; set; }
}
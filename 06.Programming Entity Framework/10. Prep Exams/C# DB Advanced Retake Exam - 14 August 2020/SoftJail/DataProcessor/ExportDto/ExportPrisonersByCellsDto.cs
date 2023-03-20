using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto;

public class ExportPrisonersByCellsDto
{
    [JsonProperty("Id")]
    public int PrisonerId { get; set; }

    [JsonProperty("Name")]
    public string PrisonerName { get; set; }

    [JsonProperty("CellNumber")]
    public int CellNumber { get; set; }

    [JsonProperty("Officers")]
    public ExportOfficerDto[] Officers { get; set; }

    [JsonProperty("TotalOfficerSalary")]
    public decimal TotalOfficerSalary { get; set; }

}

public class ExportOfficerDto
{
    [JsonProperty("OfficerName")]
    public string OfficerName { get; set; }

    [JsonProperty("Department")]
    public string Department { get; set; }
}
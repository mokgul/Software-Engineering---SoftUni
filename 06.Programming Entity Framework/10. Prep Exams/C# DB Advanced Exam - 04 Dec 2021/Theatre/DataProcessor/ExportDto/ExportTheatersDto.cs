using Newtonsoft.Json;

namespace Theatre.DataProcessor.ExportDto;

public class ExportTheatersDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Halls")]
    public int Halls { get; set; }

    [JsonProperty("TotalIncome")]
    public decimal TotalIncome { get; set; }

    [JsonProperty("Tickets")]
    public ExportTicketDto[] Tickets { get; set; }

}

public class ExportTicketDto
{
    [JsonProperty("Price")]
    public decimal Price { get; set; }

    [JsonProperty("RowNumber")]
    public int RowNumber { get; set; }
}
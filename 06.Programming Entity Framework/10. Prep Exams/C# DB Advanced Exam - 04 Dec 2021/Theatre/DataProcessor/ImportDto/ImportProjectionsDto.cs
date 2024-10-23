using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Theatre.Data;

namespace Theatre.DataProcessor.ImportDto;

public class ImportProjectionsDto
{
    [Required]
    [MinLength(ValidationConstants.TheaterNameLengthMin)]
    [MaxLength(ValidationConstants.TheaterNameLengthMax)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [Range(ValidationConstants.TheaterNumberOfHallsMin, ValidationConstants.TheaterNumberOfHallsMax)]
    [JsonProperty("NumberOfHalls")]
    public int NumberOfHalls { get; set; }

    [Required]
    [MinLength(ValidationConstants.TheaterDirectorNameLengthMin)]
    [MaxLength(ValidationConstants.TheaterDirectorNameLengthMax)]
    [JsonProperty("Director")]
    public string Director { get; set; }

    
    [JsonProperty("Tickets")]
    public ImportTicketDto[] Tickets { get; set; }

}

public class ImportTicketDto
{
    [Required]
    [Range(ValidationConstants.TicketPriceRangeMin, ValidationConstants.TicketPriceRangeMax)]
    [JsonProperty("Price")]
    public decimal Price { get; set; }

    [Required]
    [Range(ValidationConstants.TicketRowNumberMin, ValidationConstants.TicketRowNumberMax)]
    [JsonProperty("RowNumber")]
    public int RowNumber { get; set; }

    [Required]
    [JsonProperty("PlayId")]
    public int PlayId { get; set; }
}
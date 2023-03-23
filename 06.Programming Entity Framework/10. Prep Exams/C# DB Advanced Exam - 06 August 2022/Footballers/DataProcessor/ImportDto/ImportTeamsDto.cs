using System.ComponentModel.DataAnnotations;
using Footballers.Data;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto;

public class ImportTeamsDto
{
    [Required]
    [RegularExpression(ValidationConstants.TeamNameValidationRegex)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [MinLength(ValidationConstants.TeamNationalityLengthMin)]
    [MaxLength(ValidationConstants.TeamNationalityLengthMax)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set;}

    [Required]
    [JsonProperty("Trophies")]
    public int Trophies { get; set; }

    [JsonProperty("Footballers")]
    public int[] FootballersIds { get; set; }

}
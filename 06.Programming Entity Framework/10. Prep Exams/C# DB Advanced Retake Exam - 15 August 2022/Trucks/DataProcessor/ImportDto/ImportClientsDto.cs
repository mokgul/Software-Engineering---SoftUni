using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Trucks.Data;

namespace Trucks.DataProcessor.ImportDto;

public class ImportClientsDto
{
    [JsonRequired]
    [MinLength(ValidationConstants.ClientNameMinLength)]
    [MaxLength(ValidationConstants.ClientNameMaxLength)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonRequired]
    [MinLength(ValidationConstants.NationalityMinLength)]
    [MaxLength(ValidationConstants.NationalityMaxLength)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set; }

    [JsonRequired]
    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Trucks")]
    public int[] TruckIds { get; set; }
}
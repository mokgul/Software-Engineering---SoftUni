using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ImportDto;

public class ImportGamesDto
{
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [Range(0, Double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [JsonProperty("ReleaseDate")]
    public string ReleaseDate { get; set; }

    [Required]
    [JsonProperty("Developer")]
    public string DeveloperName { get; set; }

    [Required]
    [JsonProperty("Genre")]
    public string Genre { get; set; }

    [Required]
    [JsonProperty("Tags")]
    public string[] Tags { get; set; }

}

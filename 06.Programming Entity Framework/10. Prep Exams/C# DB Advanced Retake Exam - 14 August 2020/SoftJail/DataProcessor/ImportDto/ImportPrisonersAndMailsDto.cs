namespace SoftJail.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Data.Models;

public class ImportPrisonersAndMailsDto
{
    [Required]
    [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
    [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
    [JsonProperty("FullName")]
    public string FullName { get; set; }

    [Required]
    [RegularExpression(@"^The [A-Z]{1}[a-z]+$")]
    [JsonProperty("Nickname")]
    public string Nickname { get; set; }

    [Required]
    [Range(ValidationConstants.PrisonerAgeValueRangeMin, ValidationConstants.PrisonerAgeValueRangeMax)]
    [JsonProperty("Age")]
    public int Age { get; set; }

    [Required]
    [JsonProperty("IncarcerationDate")]
    public string IncarcerationDate { get; set; }

    [JsonProperty("ReleaseDate")]
    public string? ReleaseDate { get; set; }

    [Range(0, Double.MaxValue)]
    [JsonProperty("Bail")]
    public decimal? Bail { get; set; }

    [JsonProperty("CellId")]
    public int CellId { get; set; }

    [JsonProperty("Mails")]
    public ImportMailDto[] Mails { get; set; }

}

public class ImportMailDto
{
    [Required]
    [JsonProperty("Description")]
    public string Description { get; set; }

    [Required]
    public string Sender { get; set; }

    [Required]
    [RegularExpression(@"^[A-Za-z0-9 ]+ str\.$")]
    public string Address { get; set; }
}
namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Data;
using Newtonsoft.Json;

public class ImportSellersDto
{
    [Required]
    [MinLength(ValidationConstants.SellerNameLengthMin)]
    [MaxLength(ValidationConstants.SellerNameLengthMax)]
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.SellerAddressLengthMin)]
    [MaxLength(ValidationConstants.SellerAddressLengthMax)]
    [JsonProperty("Address")]
    public string Address { get; set; } = null!;

    [Required]
    [JsonProperty("Country")]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.SellerWebsiteValidation)]
    [JsonProperty("Website")]
    public string Website { get; set; } = null!;

    [JsonProperty("Boardgames")]
    public int[] Boardgames { get; set; }

}
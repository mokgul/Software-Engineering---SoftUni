using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ImportDto;

public class ImportUsersAndCardsDto
{
    [Required]
    [RegularExpression(@"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b")]
    [JsonProperty("FullName")]
    public string FullName { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    [JsonProperty("Username")]
    public string Username { get; set; }

    [Required]
    [JsonProperty("Email")]
    public string Email { get; set; }

    [Required]
    [Range(3,103)]
    [JsonProperty]
    public int Age { get; set; }

    [JsonProperty("Cards")]
    public ImportCardDto[] Cards { get; set; }
    
}

public class ImportCardDto
{
    [Required]
    [RegularExpression(@"\b\d{4}\b \b\d{4}\b \b\d{4}\b \b\d{4}\b")]
    [JsonProperty("Number")]
    public string CardNumber { get; set; }

    [Required]
    [RegularExpression(@"\b\d{3}\b")]
    [JsonProperty("CVC")]
    public string Cvc { get; set; }

    [Required]
    [JsonProperty("Type")]
    public string CardType { get; set; }
}
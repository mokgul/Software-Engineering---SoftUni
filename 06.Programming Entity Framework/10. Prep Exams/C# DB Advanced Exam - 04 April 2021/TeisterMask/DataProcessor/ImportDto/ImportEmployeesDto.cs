namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using Data;

public class ImportEmployeesDto
{
    [Required]
    [RegularExpression(ValidationConstants.UsernameValidation)]
    [JsonProperty("Username")]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [JsonProperty("Email")]
    public string EmailAddress { get; set; }

    [Required]
    [RegularExpression(ValidationConstants.PhoneValidation)]
    [JsonProperty("Phone")]
    public string Phone { get; set; }

    [JsonProperty("Tasks")]
    public int[] TaskIds { get; set; }
}
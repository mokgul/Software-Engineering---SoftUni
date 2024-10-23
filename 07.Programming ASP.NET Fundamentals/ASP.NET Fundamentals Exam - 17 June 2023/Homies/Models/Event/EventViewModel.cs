namespace Homies.Models.Event;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static Homies.Data.DataValidationConstants.Event;

public class EventViewModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime Start { get; set; }

    [Required]
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

}

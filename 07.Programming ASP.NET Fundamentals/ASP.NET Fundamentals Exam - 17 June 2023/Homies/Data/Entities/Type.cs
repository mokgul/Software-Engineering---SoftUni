namespace Homies.Data.Entities;

using System.ComponentModel.DataAnnotations;

using static Homies.Data.DataValidationConstants.Type;

public class Type
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public IEnumerable<Event> Events { get; set; } = new List<Event>();
}


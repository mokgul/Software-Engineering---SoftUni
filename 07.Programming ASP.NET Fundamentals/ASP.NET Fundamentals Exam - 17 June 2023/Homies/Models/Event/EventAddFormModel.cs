namespace Homies.Models.Event;

using System.ComponentModel.DataAnnotations;

using Homies.Models.Type;
using static Homies.Data.DataValidationConstants.Event;


public class EventAddFormModel
{
    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime Start { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime End { get; set; }

    [Required]
    public int TypeId { get; set; }

    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}


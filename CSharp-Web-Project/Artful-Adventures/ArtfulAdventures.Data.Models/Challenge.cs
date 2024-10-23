namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.DataModelsValidationConstants.ChallengeConstants;

/// <summary>
/// Represents a challenge in the database.
/// </summary>
public class Challenge
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(CreatorMaxLength)]
    public string Creator { get; set; } = null!;

    public int Participants { get; set; }

    [Required]
    [MaxLength(RequirementsMaxLength)]
    public string Requirements { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime CreatedOn { get; set; }

    [Required]
    [MaxLength(UrlMaxLength)]
    public string Url { get; set; } = null!;
    
    public ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();
}


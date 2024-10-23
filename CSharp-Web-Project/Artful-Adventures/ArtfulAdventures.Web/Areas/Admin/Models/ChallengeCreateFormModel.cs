namespace ArtfulAdventures.Web.Areas.Admin.Models;

using System.ComponentModel.DataAnnotations;

using static Common.DataModelsValidationConstants.ChallengeConstants;

/// <summary>
///  This is a view model for the challenge entity.
/// </summary>
public class ChallengeCreateFormModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    public string Creator { get; set; } = null!;

    public int Participants { get; set; }

    [Required]
    [StringLength(RequirementsMaxLength, MinimumLength = RequirementsMinLength)]
    public string Requirements { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime CreatedOn { get; set; }

    [StringLength(UrlMaxLength, MinimumLength = UrlMinLength)]
    public string ImageUrl { get; set; } = null!;

}


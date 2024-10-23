namespace ArtfulAdventures.Web.ViewModels.Picture;

using System.ComponentModel.DataAnnotations;

using HashTag;
using static Common.DataModelsValidationConstants.PictureConstants;

/// <summary>
///  This ViewModel is used in the PictureController's Add action.
/// </summary>
public class PictureAddFormModel
{
    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;


    public List<HashTagViewModel> HashTags { get; set; } = new List<HashTagViewModel>();
}


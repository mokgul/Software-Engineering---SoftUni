namespace ArtfulAdventures.Web.ViewModels.Blog;

using System.ComponentModel.DataAnnotations;

using static Common.DataModelsValidationConstants.BlogConstants;

/// <summary>
///  This is the model for the blog add form.
/// </summary>
public class BlogAddFormModel
{
    //this is for edit only
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
    public string Content { get; set; } = null!;

    [StringLength(UrlMaxLength, MinimumLength = UrlMaxLength)]
    public string? ImageUrl { get; set; }
}


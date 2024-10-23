namespace ArtfulAdventures.Web.ViewModels.Blog;

/// <summary>
///  This is a view model for the BlogController's Index action.
/// </summary>
public class BlogVisualizeModel
{
    public ICollection<BlogDetailsViewModel> Blogs { get; set; } = null!;
}


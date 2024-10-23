namespace ArtfulAdventures.Web.ViewModels.Search;

/// <summary>
///  This class is used to display the search results for blogs.
/// </summary>
public class BlogSearchViewModel
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string Content { get; set; } = null!;
}


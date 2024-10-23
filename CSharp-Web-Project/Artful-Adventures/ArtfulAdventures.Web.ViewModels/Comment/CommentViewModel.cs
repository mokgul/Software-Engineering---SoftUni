namespace ArtfulAdventures.Web.ViewModels.Comment;

/// <summary>
///  This view model is used to display the details of a comment.
/// </summary>
public class CommentViewModel
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? AuthorPictureUrl { get; set; }

    public DateTime CreatedOn { get; set; }
}


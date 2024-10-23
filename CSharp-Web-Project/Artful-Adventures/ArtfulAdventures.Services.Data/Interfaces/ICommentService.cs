namespace ArtfulAdventures.Services.Data.Interfaces;

/// <summary>
///  Defines the <see cref="ICommentService" />.
/// </summary>
public interface ICommentService
{
    Task AddCommentPicture(string content, string pictureId, string userId);

    Task AddCommentBlog(string content, string blogId, string userId);
}
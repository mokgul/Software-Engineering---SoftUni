namespace ArtfulAdventures.Services.Data;

using Interfaces;
using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;


/// <summary>
///  Provides the functionality for adding a comment to a picture or a blog.
/// </summary>
public class CommentService : ICommentService
{
    private readonly ArtfulAdventuresDbContext _data;
    public CommentService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }
    
    /// <summary>
    ///  Provides the functionality for adding a comment to a picture.
    /// </summary>
    /// <param name="content"> The content of the comment. </param>
    /// <param name="pictureId"> The id of the picture. </param>
    /// <param name="userId"> The id of the user. </param>
    public async Task AddCommentPicture(string content, string pictureId, string userId)
    {
        var user =  _data.Users.FirstOrDefault(x => x.Id.ToString() == userId);

        var comment = new Comment
        {
            Author = user!.UserName,
            Content = content,
            CreatedOn = DateTime.UtcNow,
            PictureId = Guid.Parse(pictureId),
        };
        await _data.Comments.AddAsync(comment);
        await _data.SaveChangesAsync();
    }

    
    /// <summary>
    ///  Provides the functionality for adding a comment to a blog.
    /// </summary>
    /// <param name="content"> The content of the comment. </param>
    /// <param name="blogId"> The id of the blog. </param>
    /// <param name="userId"> The id of the user. </param>
    public async Task AddCommentBlog(string content, string blogId, string userId)
    {
        var user = _data.Users.FirstOrDefault(x => x.Id.ToString() == userId);

        var comment = new Comment
        {
            Author = user!.UserName,
            Content = content,
            CreatedOn = DateTime.UtcNow,
            BlogId = Guid.Parse(blogId),
        };
        await _data.Comments.AddAsync(comment);
        await _data.SaveChangesAsync();
    }
}
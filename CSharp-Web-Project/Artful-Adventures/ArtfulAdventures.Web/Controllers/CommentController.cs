namespace ArtfulAdventures.Web.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ArtfulAdventures.Services.Data.Interfaces;


/// <summary>
///  Provides the functionality for adding a comment to a picture or a blog.
/// </summary>
[Authorize]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    ///  Provides the functionality for adding a comment to a picture.
    /// </summary>
    /// <param name="content"> The content of the comment. </param>
    /// <param name="pictureId" > The id of the picture. </param>
    /// <returns> Redirects to the picture details page. </returns>
    [HttpPost]
    public async Task<IActionResult> AddCommentPicture(string content, string pictureId)
    {
        if (string.IsNullOrEmpty(content))
        {
            return RedirectToAction("PictureDetails", "Picture", new { id = pictureId });
        }

        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        await _commentService.AddCommentPicture(content, pictureId, userId);

        return RedirectToAction("PictureDetails", "Picture", new { id = pictureId });
    }

    
    /// <summary>
    ///  Provides the functionality for adding a comment to a blog.
    /// </summary>
    /// <param name="content"> The content of the comment. </param>
    /// <param name="blogId"> The id of the blog. </param>
    /// <returns> Redirects to the blog details page. </returns>
    [HttpPost]
    public async Task<IActionResult> AddCommentBlog(string content, string blogId)
    {
        if (string.IsNullOrEmpty(content))
        {
            return RedirectToAction("BlogDetails", "Blog", new { id = blogId });
        }

        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        await _commentService.AddCommentBlog(content, blogId, userId);
        return RedirectToAction("BlogDetails", "Blog", new { id = blogId });
    }
}
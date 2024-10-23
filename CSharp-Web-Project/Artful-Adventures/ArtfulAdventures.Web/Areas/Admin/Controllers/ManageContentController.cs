namespace ArtfulAdventures.Web.Areas.Admin.Controllers;

using System.Drawing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ArtfulAdventures.Services.Common;
using Configuration;
using static Common.GeneralApplicationConstants.Roles;
using static Common.GeneralApplicationConstants;
using Models;
using Services.Interfaces;


/// <summary>
///  Controller for the admin panel used for managing content.
/// </summary>
[Authorize(Roles = Administrator)]
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class ManageContentController : Controller
{
    private readonly IManageContentService _manageContentService;

    public ManageContentController(IManageContentService service)
    {
        _manageContentService = service;
    }

    /// <summary>
    ///  Provides functionality for deleting a picture.
    /// </summary>
    /// <param name="pictureId"> The pictureId <see cref="string"/>.</param>
    /// <param name="user"> The user <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DeletePicture(string pictureId, string user)
    {
        try
        {
            var path = await _manageContentService.DeletePictureAsync(pictureId, user);
            await DeleteFromFtpServer.DeleteFile(path);
            TempData["AdminDelete"] = "Picture deleted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for deleting a blog.
    /// </summary>
    /// <param name="blogId"> The blogId <see cref="string"/>.</param>
    /// <param name="user"> The user <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DeleteBlog(string blogId, string user)
    {
        try
        {
            await _manageContentService.DeleteBlogAsync(blogId, user);
            TempData["AdminDelete"] = "Blog deleted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for deleting a comment from a picture.
    /// </summary>
    /// <param name="pictureId"> The pictureId <see cref="string"/>.</param>
    /// <param name="commentId"> The commentId <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DeleteCommentPicture(string pictureId, string commentId)
    {
        try
        {
            await _manageContentService.DeleteCommentPictureAsync(pictureId, commentId);
            TempData["AdminDeleteComment"] = "Comment deleted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteCommentError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for deleting a comment from a blog.
    /// </summary>
    /// <param name="blogId"> The blogId <see cref="string"/>.</param>
    /// <param name="commentId"> The commentId <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DeleteCommentBlog(string blogId, string commentId)
    {
        try
        {
            await _manageContentService.DeleteCommentBlogAsync(blogId, commentId);
            TempData["AdminDeleteComment"] = "Comment deleted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteCommentError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Gets a form for creating a challenge.
    /// </summary>
    /// <returns> A view with the form. </returns>
    [HttpGet]
    public async Task<IActionResult> CreateChallenge()
    {
        var userId = GetUserId();
        try
        {
            var model = await _manageContentService.CreateChallengeGetFormAsync(userId);
            return View(model);
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for creating a challenge.
    /// </summary>
    /// <param name="model"> The model <see cref="ChallengeCreateFormModel"/>.</param>
    /// <returns> A redirect to the challenge details page. </returns>
    [HttpPost]
    public async Task<IActionResult> CreateChallenge(ChallengeCreateFormModel model)
    {
        try
        {
            var path = await UploadFile();
            if (string.IsNullOrEmpty(path))
            {
                TempData["AdminCreateError"] = "Please upload a picture!";
                ModelState.AddModelError(path, "Please upload a picture!");
            }

            ModelState.Remove("ImageUrl");
            if (!ModelState.IsValid)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                    Path.GetFileName(path)));
                return View(model);
            }

            int challengeId = await _manageContentService.CreateChallengeAsync(model, path);
            TempData["AdminCreateChallenge"] = "Challenge created successfully!";
            return RedirectToAction("ChallengeDetails", "Challenge", new { id = challengeId, area = "" });
        }
        catch (Exception ex)
        {
            TempData["AdminCreateError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for deleting a challenge.
    /// </summary>
    /// <param name="challengeId"> The challengeId <see cref="int"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DeleteChallenge(int challengeId)
    {
        try
        {
            var path = await _manageContentService.DeleteChallengeAsync(challengeId);
            if (string.IsNullOrEmpty(path) || path == "invalid-file")
            {
                TempData["AdminDeleteError"] = "Invalid file!";
                return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
            }

            await DeleteFromFtpServer.DeleteFile(path);
            TempData["AdminDelete"] = "Challenge deleted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDeleteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Gets the user id.
    /// </summary>
    /// <returns></returns>
    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    
    /// <summary>
    ///  Uploads a file to the server.
    /// </summary>
    /// <returns></returns>
    private async Task<string> UploadFile()
    {
        //Reads the form data from the request body.
        var form = await Request.ReadFormAsync();
        if (form.Files.Count == 0)
        {
            return string.Empty;
        }

        var imageValidator = new ValidateFileIsImage();
        if (imageValidator.Validate(form.Files.First()) == false)
        {
            return "invalid-file";
        }

        //Gets the first file and saves it to the specified path.
        var file = form.Files.First();
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

        //Resize the image
        Bitmap newImage = SaveFileLocal.ResizeImage(file);
        SaveFileLocal.SaveAsync(filePath, newImage);

        //Get the URL of the file to be uploaded
        var url = Path.Combine(ftpServerUrl, fileName);

        //Upload the file to the FTP server
        await UploadToFtpServer.UploadFile(fileName, filePath);

        return url;
    }
}
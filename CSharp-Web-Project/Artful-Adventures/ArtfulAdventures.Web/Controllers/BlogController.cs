namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Drawing;

using ArtfulAdventures.Services.Common;
using ArtfulAdventures.Services.Data.Interfaces;
using Configuration;
using ViewModels.Blog;
using static Common.GeneralApplicationConstants;

/// <summary>
///  Provides a controller for the blog.
/// </summary>
[Authorize]
public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService service)
    {
        _blogService = service;
    }

    /// <summary>
    ///  Provides a method for a collection of all blogs.
    /// </summary>
    /// <param name="sort"> A string for sorting the blogs. </param>
    /// <param name="page"> An int for the page number. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> GetBlogs(string sort, int page)
    {
        var model = await _blogService.GetAllBlogsAsync(sort, page);
        if (model == null)
        {
            TempData["Error"] = "Invalid page number.";
            return RedirectToAction("GetBlogs", new { sort = "", page = 1 });
        }

        ViewBag.Sort = sort;
        ViewBag.CurrentPage = page;
        ViewBag.Action = "GetBlogs";

        return View(model);
    }


    /// <summary>
    ///  Provides a method for getting the blog view model for creating a blog.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> CreateBlog()
    {
        ViewBag.Action = "CreateBlog";

        var model = await _blogService.GetBlogViewModelAsync();

        return View(model);
    }


    /// <summary>
    ///  Provides a method for creating a blog.
    /// </summary>
    /// <param name="model"> The model <see cref="BlogAddFormModel"/> for blog creation. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    /// <exception cref="ArgumentException"> Throws an exception if the file is not an image. </exception>
    [HttpPost]
    public async Task<IActionResult> CreateBlog(BlogAddFormModel model)
    {
        var userId = GetUserId();
        try
        {
            var path = await UploadFile();
            if (path == "invalid-file")
                throw new ArgumentException("Invalid file type. Please upload a valid image.");

            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _blogService.CreateBlogAsync(model, userId, path);
        }
        catch (ArgumentException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("CreateBlog", "Blog");
        }

        TempData["Success"] = "Your blog was published successfully!";

        return RedirectToAction("CreateBlog", "Blog");
    }


    /// <summary>
    ///  Provides a method for getting the blogs details.
    /// </summary>
    /// <param name="id"> A string for the blog id. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> BlogDetails(string id)
    {
        var currentUser = GetUserId();
        var model = await _blogService.GetBlogDetailsAsync(id, currentUser);

        if (model != null) return View(model);

        TempData["Error"] = "Blog not found.";
        return RedirectToAction("GetBlogs", new { sort = "", page = 1 });
    }


    /// <summary>
    ///  Provides a method for liking a blog.
    /// </summary>
    /// <param name="blogId"> A string for the blog id. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpPost]
    public async Task<IActionResult> Like(string blogId)
    {
        var success = await _blogService.LikeBlogAsync(blogId);

        if (success) return RedirectToAction("BlogDetails", new { id = blogId });
        TempData["Message"] = "Something went wrong. Please try again later.";

        return RedirectToAction("BlogDetails", new { id = blogId });
    }


    /// <summary>
    ///  Provides a method for getting all the blogs for the current user for managing.
    /// </summary>
    /// <param name="sort"> A string for sorting the blogs. </param>
    /// <param name="page"> An int for the page number. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> ManageBlogs(string sort, int page)
    {
        var userId = GetUserId();
        var model = await _blogService.GetAllBlogsForManageAsync(sort, userId, page);

        ViewBag.Sort = sort;
        ViewBag.CurrentPage = page;
        ViewBag.Action = "ManageBlogs";

        if (model != null)
            return View("GetBlogs", model);

        return RedirectToAction("ManageBlogs", new { sort = "", page = 1 });
    }


    /// <summary>
    ///  Provides a method for getting the blog view model for editing a blog.
    /// </summary>
    /// <param name="id"> A string for the blog id. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> EditBlog(string id)
    {
        ViewBag.Action = "EditBlog";
        var model = await _blogService.GetBlogToEditAsync(id);

        if (model != null)
            return View("CreateBlog", model);

        TempData["NotFound"] = "Blog not found.";
        return RedirectToAction("ManageBlogs", "Blog");
    }


    /// <summary>
    ///  Provides a method for editing a blog.
    /// </summary>
    /// <param name="model"> The model <see cref="BlogAddFormModel"/> for blog editing. </param>
    /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
    [HttpPost]
    public async Task<IActionResult> EditBlog(BlogAddFormModel model)
    {
        var id = model.Id;
        try
        {
            var path = await UploadFile();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("ManageBlogs", "Blog");
            }

            await _blogService.EditBlogAsync(model, id, path);
        }
        catch (Exception)
        {
            TempData["Error"] = "Something went wrong. Please try again later.";
            return RedirectToAction("ManageBlogs", "Blog");
        }

        TempData["Success"] = "Your blog was edited successfully!";

        return RedirectToAction("ManageBlogs", "Blog");
    }


    /// <summary>
    ///  Provides a method for deleting a blog.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> DeleteBlog(string id)
    {
        var userId = GetUserId();
        try
        {
            await _blogService.DeleteBlogAsync(id, userId);
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("ManageBlogs", "Blog");
        }

        TempData["Success"] = "Your blog was deleted successfully!";

        return RedirectToAction("ManageBlogs", "Blog");
    }


    /// <summary>
    /// Provides a method for uploading a picture for the blog.
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

        //Gets the first file and saves it to the specified path.
        var file = form.Files.First();
        var imageValidator = new ValidateFileIsImage();
        if (imageValidator.Validate(file) == false)
            return "invalid-file";
        var fileName = file.FileName;
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


    /// <summary>
    ///  Provides a method for getting the current user id.
    /// </summary>
    /// <returns></returns>
    private string GetUserId()
    {
        return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
}
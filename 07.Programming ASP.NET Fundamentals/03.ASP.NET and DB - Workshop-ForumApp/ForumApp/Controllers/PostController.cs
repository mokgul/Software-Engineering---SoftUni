using Forum.Services.Interfaces;
using ForumViewModels.Post;

namespace ForumApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class PostController : Controller
{

    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<PostListViewModel> allPosts = await _postService.ListAllAsync();

        return View(allPosts);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this._postService.AddPostAsync(model);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

            return View(model);
        }

        return RedirectToAction("All", "Post");
    }

    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            PostFormModel postModel = await this._postService.GetItemForEditOrDelete(id);
            return View(postModel);
        }
        catch (Exception)
        {
            return this.RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, PostFormModel postModel)
    {
        if (!ModelState.IsValid)
        {
            return View(postModel);
        }

        try
        {
            await _postService.EditByIdAsync(id, postModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

            return View(postModel);
        }

        return RedirectToAction("All", "Post");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _postService.DeleteByIdAsync(id);
        }
        catch (Exception)
        {

        }

        return RedirectToAction("All", "Post");
    }
}


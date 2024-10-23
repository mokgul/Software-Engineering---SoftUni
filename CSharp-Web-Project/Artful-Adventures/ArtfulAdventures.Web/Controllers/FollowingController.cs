namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ArtfulAdventures.Services.Data.Interfaces;


/// <summary>
///  Provides actions for the Following page.
/// </summary>
[Authorize]
public class FollowingController : Controller
{
    private readonly IFollowingService _followingService;

    public FollowingController(IFollowingService service)
    {
        _followingService = service;
    }

    
    /// <summary>
    ///  Provides a view model for the Following page.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A view model for the Following page. </returns>
    [HttpGet]
    public async Task<IActionResult> All(string sort, int page)
    {
        try
        {
            var username = User!.Identity!.Name!;
            var model = await _followingService.GetExploreViewModelAsync(sort, page, username);

            ViewBag.Sort = sort;
            ViewBag.CurrentPage = page;
            return View(model);
        }
        catch (Exception ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("All", "Following", new { sort = "", page = 1 });
        }
    }
}
namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ArtfulAdventures.Services.Data.Interfaces;

/// <summary>
///  Provides functionality for the Explore page.
/// </summary>
[Authorize]
public class ExploreController : Controller
{
    private readonly IExploreService _exploreService;

    public ExploreController(IExploreService service)
    {
        _exploreService = service;
    }

    /// <summary>
    ///  Provides a view model for the Explore page.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A view model for the Explore page. </returns>
    [HttpGet]
    public async Task<IActionResult> All(string sort, int page)
    {
        try
        {
            var model = await _exploreService.GetExploreViewModelAsync(sort, page);

            ViewBag.Sort = sort;
            ViewBag.CurrentPage = page;

            return View(model);
        }
        catch (ArgumentException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("All", "Explore", new { sort = "", page = 1 });
        }
    }
}
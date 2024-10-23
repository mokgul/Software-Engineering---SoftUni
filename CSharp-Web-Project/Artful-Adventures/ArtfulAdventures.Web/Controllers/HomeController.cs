namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using ArtfulAdventures.Services.Data.Interfaces;
using ViewModels.Home;


/// <summary>
///  The home controller is responsible for the home page and the search functionality.
/// </summary>
public class HomeController : Controller
{
    private readonly ISearchService _searchService;
    private readonly IExploreService _exploreService;

    public HomeController(ISearchService searchService, IExploreService exploreService)
    {
        _searchService = searchService;
        _exploreService = exploreService;
    }
    

    /// <summary>
    ///  The index action returns the home page with the latest 20 pictures.
    /// </summary>
    /// <returns> The home page view. </returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await _exploreService.GetPicturesForHomePageAsync();
        return View(model);
    }

    
    /// <summary>
    ///  The about us action returns the about us page.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> AboutUs()
    {
        return View();
    }
    
    
    /// <summary>
    ///  The privacy action returns the privacy page.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Privacy()
    {
        return View();
    }

    /// <summary>
    ///  The search action returns the search results page.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Search(string query, int page = 1)
    {
        if(query == null)
        {
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Query = query;
        var model = await _searchService.SearchAsync(query, page);
        return View(model);
    }

    
    /// <summary>
    ///  The error action returns the error page.
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

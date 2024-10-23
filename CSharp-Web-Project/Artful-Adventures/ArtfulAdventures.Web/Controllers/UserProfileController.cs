namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ArtfulAdventures.Services.Data.Interfaces;


/// <summary>
/// Provides methods for the user profile page.
/// </summary>
[Authorize]
public class UserProfileController : Controller
{
    private readonly IProfileService _profileService;

    public UserProfileController(IProfileService service)
    {
        _profileService = service;
    }

    /// <summary>
    ///  Returns a ProfileViewModel for the given username.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A ProfileViewModel.</returns>
    [HttpGet]
    public async Task<IActionResult> Profile(string username)
    {
        var model = await _profileService.GetProfileViewModelAsync(username, GetUserId());
        if (model == null)
        {
            return RedirectToAction("NonExistingProfile");
        }

        return View(model);
    }

    
    /// <summary>
    ///  Returns a ProfileViewModel for non-existing profile.
    /// </summary>
    /// <returns></returns>
    public IActionResult NonExistingProfile()
    {
        return View();
    }

    
    /// <summary>
    ///  Provides a method for following a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns>A redirect to the Profile action.</returns>
    [HttpPost]
    public async Task<IActionResult> Follow(string username)
    {
        try
        {
            var result = await _profileService.FollowAsync(username, GetUserId());
            if (string.IsNullOrEmpty(result))
            {
                TempData["Message"] = "You cannot follow yourself.";
                return RedirectToAction("Profile", new { username = username });
            }

            TempData["Success"] = "You are now following this user.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            return RedirectToAction("Profile", new { username = username });
        }
    }
    
    
    /// <summary>
    ///  Provides a method for unfollowing a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A redirect to the Profile action.</returns>
    [HttpPost]
    public async Task<IActionResult> Unfollow(string username)
    {
        try
        {
            await _profileService.UnfollowAsync(username, GetUserId());
            TempData["Success"] = "You are no longer following this user.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            TempData["Message"] = "Something went wrong.";
            return RedirectToAction("Profile", new { username = username });
        }
    }
    
    
    /// <summary>
    ///  Provides a method for displaying the user's portfolio.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A PortfolioViewModel.</returns>
    [HttpGet]
    public async Task<IActionResult> Portfolio(string username)
    {
        try
        {
            var model = await _profileService.GetPortfolioAsync(username);

            if (model != null) 
                return View(model);
            
            TempData["Message"] = "No portfolio yet.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            TempData["Error"] = "Something went wrong.";
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }
    }

    
    /// <summary>
    ///  Provides a method for displaying the user's favorites.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A CollectionViewModel.</returns>
    [HttpGet]
    public async Task<IActionResult> Favorites(string username)
    {
        try
        {
            var model = await _profileService.GetCollectionAsync(username);

            if (model != null) 
                return View(model);
            
            TempData["Message"] = "No favorites yet.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            TempData["Error"] = "Something went wrong.";
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }
    }

    
    /// <summary>
    ///  Provides a method for displaying the user's followers.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A FollowersViewModel.</returns>
    [HttpGet]
    public async Task<IActionResult> Followers(string username)
    {
        try
        {
            var model = await _profileService.GetFollowersAsync(username);
            if (model != null) 
                return View(model);
            
            TempData["Message"] = "No followers yet.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            TempData["Error"] = "Something went wrong.";
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }
    }

    
    /// <summary>
    ///  Provides a method for displaying the user's following.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A FollowingViewModel.</returns>
    [HttpGet]
    public async Task<IActionResult> Following(string username)
    {
        try
        {
            var model = await _profileService.GetFollowingAsync(username);
            if (model != null) 
                return View(model);
            
            TempData["Message"] = "No following yet.";
            return RedirectToAction("Profile", new { username = username });
        }
        catch
        {
            TempData["Error"] = "Something went wrong.";
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }
    }

    
    /// <summary>
    ///  Provides a method for getting the current user's id.
    /// </summary>
    /// <returns></returns>
    private string GetUserId()
    {
        return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
}
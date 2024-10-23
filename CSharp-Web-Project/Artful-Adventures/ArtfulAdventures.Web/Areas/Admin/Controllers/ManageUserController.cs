namespace ArtfulAdventures.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using static Common.GeneralApplicationConstants.Roles;

/// <summary>
///  Controller for the admin panel used for managing users.
/// </summary>
[Authorize(Roles = Administrator)]
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class ManageUserController : Controller
{
    private readonly IManageUserService _manageUserService;

    public ManageUserController(IManageUserService service)
    {
        _manageUserService = service;
    }


    /// <summary>
    ///  Provides functionality for getting a user.
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUser(string username)
    {
        var user = await _manageUserService.GetUserAsync(username);
        if (user.Count != 0)
            return View("AllUsers", user);
        TempData["AdminUserError"] = "User not found!";
        return RedirectToAction("AllUsers", "ManageUser", new { page = 1, area = "Admin" });
    }


    /// <summary>
    ///  Provides functionality for getting all users.
    /// </summary>
    /// <param name="page"> The page <see cref="int"/>.</param>
    /// <returns> A view with all users. </returns>
    [HttpGet]
    public async Task<IActionResult> AllUsers(int page)
    {
        ViewBag.CurrentPage = page;
        var users = await _manageUserService.GetAllUsersAsync(page);
        return View(users);
    }
    
    
    /// <summary>
    ///  Provides functionality for promoting a user to admin.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> PromoteToAdmin(string username)
    {
        if (username == User!.Identity!.Name)
        {
            TempData["AdminPromoteError"] = "You cannot promote yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.PromoteToAdminAsync(username);
            TempData["AdminPromote"] = "User promoted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminPromoteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for demoting an admin to user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> DemoteAdmin(string username)
    {
        if (username == User!.Identity!.Name)
        {
            TempData["AdminDemoteError"] = "You cannot demote yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.DemoteAdminAsync(username);
            await _manageUserService.SetDefaultRoleAsync(username);

            TempData["AdminDemote"] = "Admin demoted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminDemoteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for muting a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <param name="days"> The duration of the mute <see cref="int"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> MuteUser(string username, int days)
    {
        var admin = User!.Identity!.Name;
        if (username == User!.Identity!.Name)
        {
            TempData["AdminMuteError"] = "You cannot mute yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.MuteUserAsync(username, days, admin);
            TempData["AdminMute"] = "User muted successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminMuteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for removing a mute from a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> UnmuteUser(string username)
    {
        if (username == User!.Identity!.Name)
        {
            TempData["AdminMuteError"] = "You cannot unmute yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.UnmuteUserAsync(username);
            TempData["AdminMute"] = "User is no longer muted!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminMuteError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for banning a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> BanUser(string username)
    {
        if (username == User!.Identity!.Name)
        {
            TempData["AdminBanError"] = "You cannot ban yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.BanUserAsync(username);
            TempData["AdminBan"] = "User banned successfully!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminBanError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }

    
    /// <summary>
    ///  Provides functionality for removing a ban from a user.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A redirect to the admin panel. </returns>
    [HttpPost]
    public async Task<IActionResult> UnbanUser(string username)
    {
        if (username == User!.Identity!.Name)
        {
            TempData["AdminBanError"] = "You cannot unban yourself!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }

        try
        {
            await _manageUserService.UnbanUserAsync(username);
            TempData["AdminBan"] = "User is no longer banned!";
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
        catch (ArgumentException ex)
        {
            TempData["AdminBanError"] = ex.Message;
            return RedirectToAction("Panel", "AdminPanel", new { area = "Admin" });
        }
    }
    
    
    /// <summary>
    ///  Provides functionality for getting all admins.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> AllAdmins()
    {
        var admins = await _manageUserService.GetAllAdminsAsync();
        return View("AllUsers", admins);
    }
    
    
    /// <summary>
    ///  Provides functionality for getting all muted users.
    /// </summary>
    /// <returns> A view with all muted users. </returns>
    [HttpGet]
    public async Task<IActionResult> AllMutedUsers()
    {
        var mutedUsers = await _manageUserService.GetAllMutedUsersAsync();
        return View("AllUsers", mutedUsers);
    }

    
    /// <summary>
    ///  Provides functionality for getting all banned users.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> AllBannedUsers()
    {
        var bannedUsers = await _manageUserService.GetAllBannedUsersAsync();
        return View("AllUsers", bannedUsers);
    }
}
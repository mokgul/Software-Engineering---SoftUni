namespace ArtfulAdventures.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Common.GeneralApplicationConstants.Roles;


/// <summary>
///  Controller for the admin panel.
/// </summary>
[Authorize(Roles = Administrator)]
[Area("Admin")]
public class AdminPanelController : Controller
{
    /// <summary>
    ///  Returns the admin panel view.
    /// </summary>
    /// <returns></returns>
    public IActionResult Panel()
    {
        return View();
    }
}
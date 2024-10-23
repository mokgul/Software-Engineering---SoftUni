namespace ArtfulAdventures.Web.Components;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;

/// <summary>
///  This component is used to display the user's profile picture and username in the off-canvas menu.
/// </summary>
public class OffCanvasProfileViewComponent : ViewComponent
{
    private readonly ArtfulAdventuresDbContext _data;

    public OffCanvasProfileViewComponent(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    ///  This method is used to get the current user's username and profile picture.
    /// </summary>
    /// <returns> A view with the user's username and profile picture. </returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentUser = User!.Identity!.Name;
        var user = await _data.Users.FirstOrDefaultAsync(x => x.UserName == currentUser);
        var info = new string[]
        {
            user!.UserName, Path.GetFileName(user.Url)!
        };
        return View(info);
    }
}
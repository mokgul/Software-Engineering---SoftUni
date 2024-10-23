namespace ArtfulAdventures.Web.Components;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;

/// <summary>
///  This component is used to display the user's unread messages in the off-canvas menu.
/// </summary>
public class UnreadMessagesViewComponent : ViewComponent
{
    private readonly ArtfulAdventuresDbContext _data;

    public UnreadMessagesViewComponent(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    ///  This method is used to get the current user's unread messages.
    /// </summary>
    /// <returns> A view with the user's unread messages. </returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentUser = User.Identity.Name;
        var totalUnreadMessages = await _data.Messages
            .Include(s => s.Sender)
            .Include(r => r.Receiver)
            .Where(m => m.Receiver.UserName == currentUser && !m.IsRead)
            .CountAsync();
        return View(totalUnreadMessages);
    }
}

namespace ArtfulAdventures.Web.Areas.Admin.Models;

/// <summary>
///   This is a view model for the user entity.
/// </summary>
public class UserViewModel
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? Role { get; set; }

}


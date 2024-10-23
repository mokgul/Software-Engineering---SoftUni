namespace ArtfulAdventures.Web.ViewModels.Search;

/// <summary>
///  This class is used to display the search results for users.
/// </summary>
public class UserSearchViewModel
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? Name { get; set; }

    public int Uploads { get; set; }

}


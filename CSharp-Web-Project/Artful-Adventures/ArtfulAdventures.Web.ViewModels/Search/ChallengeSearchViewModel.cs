namespace ArtfulAdventures.Web.ViewModels.Search;

/// <summary>
///  This class is used to display the search results for challenges.
/// </summary>
public class ChallengeSearchViewModel
{
    public int Id { get; set; }

    public string Creator { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string Requirements { get; set; } = null!;

}


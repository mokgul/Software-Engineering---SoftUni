namespace ArtfulAdventures.Web.ViewModels.Challenges;

/// <summary>
///  This view model is used to display the details of a challenge.
/// </summary>
public class ChallengeDetailsViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Creator { get; set; } = null!;

    public int Participants { get; set; }

    public string Requirements { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public Dictionary<string, string> Pictures { get; set; } = new Dictionary<string, string>();
}
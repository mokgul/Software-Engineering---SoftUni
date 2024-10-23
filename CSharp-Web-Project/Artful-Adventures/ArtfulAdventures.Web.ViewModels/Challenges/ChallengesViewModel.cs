namespace ArtfulAdventures.Web.ViewModels.Challenges;

/// <summary>
///  This view model is used when displaying all challenges.
/// </summary>
public class ChallengesViewModel
{
    public ICollection<ChallengeVisualizeViewModel> Challenges { get; set; } = new HashSet<ChallengeVisualizeViewModel>();
}


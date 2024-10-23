namespace ArtfulAdventures.Web.ViewModels.UserProfile;

/// <summary>
///  This is a view model for the followers / following.
/// </summary>
public class FollowViewModel
{
    public IEnumerable<ProfilePartialView>? Followers { get; set; } = new HashSet<ProfilePartialView>();
}


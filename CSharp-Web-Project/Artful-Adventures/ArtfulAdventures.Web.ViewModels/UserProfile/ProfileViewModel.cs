namespace ArtfulAdventures.Web.ViewModels.UserProfile;

using Picture;
using Skill;

/// <summary>
///  This is a view model for the profile.
/// </summary>
public class ProfileViewModel : ProfilePartialView
{

    public string Email { get; set; } = null!;

    public string? About { get; set; }

    public bool IsMuted { get; set; }
    
    public DateTime MuteUntil { get; set; }

    public ICollection<PictureVisualizeViewModel>? Pictures { get; set; }

    public ICollection<SkillViewModel>? Skills { get; set; }

    public string Contact => this.Email;
}


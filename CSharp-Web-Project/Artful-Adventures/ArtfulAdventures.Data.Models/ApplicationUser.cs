namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using static Common.DataModelsValidationConstants.ApplicationUserConstants;

/// <summary>
/// Represents a user in the system
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid();
        ApplicationUsersSkills = new HashSet<ApplicationUserSkill>();
        Portfolio = new HashSet<ApplicationUserPicture>();
    }

    [MaxLength(UrlMaxLength)]
    public string? Url { get; set; }

    [MaxLength(NameMaxLength)]
    public string? Name { get; set; }


    [MaxLength(BioMaxLength)]
    public string? Bio { get; set; }

    [MaxLength(CityNameMaxLength)]
    public string? CityName { get; set; }

    [MaxLength(AboutMaxLength)]
    public string? About { get; set; }

    public ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();

    public ICollection<FollowerFollowing> Followers { get; set; } = new HashSet<FollowerFollowing>();

    public ICollection<FollowerFollowing> Following { get; set; } = new HashSet<FollowerFollowing>();

    public ICollection<ApplicationUserSkill> ApplicationUsersSkills { get; set; }

    public ICollection<ApplicationUserPicture> Portfolio { get; set; }

    public ICollection<ApplicationUserCollection> Collection { get; set; } = new HashSet<ApplicationUserCollection>();

    public ICollection<Message> SentMessages { get; set; } = new HashSet<Message>();

    public ICollection<Message> ReceivedMessages { get; set; } = new HashSet<Message>();

    public DateTime? MuteUntil { get; set; }
}


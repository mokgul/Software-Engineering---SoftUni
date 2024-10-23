namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Represents a follower-followed relationship between two users.
/// </summary>
public class FollowerFollowing
{
    [Required]
    [ForeignKey(nameof(Follower))]
    public Guid FollowerId { get; set; }
    public ApplicationUser? Follower { get; set; }

    [Required]
    [ForeignKey(nameof(Followed))]
    public Guid FollowedId { get; set; }
    public ApplicationUser? Followed { get; set; } 
}


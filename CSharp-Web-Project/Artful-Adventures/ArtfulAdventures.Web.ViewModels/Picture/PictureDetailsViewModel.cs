namespace ArtfulAdventures.Web.ViewModels.Picture;

using Comment;
using HashTag;

/// <summary>
///  PictureDetailsViewModel is used to display the details of a picture.
/// </summary>
public class PictureDetailsViewModel
{
    public string Id { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string? OwnerLevel { get; set; } = null!;

    public string? OwnerPictureUrl { get; set; }

    public int OwnerPicturesCount { get; set; }

    public int OwnerFollowersCount { get; set; }

    public int OwnerFollowingCount { get; set; }

    public bool isFollowed { get; set; }

    public int Likes { get; set; }

    public string Description { get; set; } = null!;

    public ICollection<HashTagViewModel>? HashTags { get; set; }

    public bool isCurrentUserMuted { get; set; }
    
    public DateTime? CreatedOn { get; set; }

    public int CommentsCount { get; set; }

    public ICollection<CommentViewModel>? Comments { get; set; }
}


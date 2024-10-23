namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;

using ArtfulAdventures.Data.Models.Enums;

/// <summary>
/// Represents a HashTag entity for a <see cref="Picture"/> entity.
/// </summary>
public class HashTag
{
    public HashTag()
    {
        PicturesHashTags = new HashSet<PictureHashTag>();
    }
    public HashTag(HashTagType type) : this()
    {
        this.Type = type.ToString();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    public ICollection<PictureHashTag> PicturesHashTags { get; set; } 
}


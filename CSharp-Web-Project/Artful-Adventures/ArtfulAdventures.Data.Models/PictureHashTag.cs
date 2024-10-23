namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Represents a many-to-many relationship between <see cref="Picture"/> and <see cref="HashTag"/>
/// </summary>
public class PictureHashTag
{
    [Required]
    [ForeignKey(nameof(Picture))]
    public Guid PictureId { get; set; }

    public Picture Picture { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Tag))]
    public int TagId { get; set; }

    public HashTag Tag { get; set; } = null!;
}


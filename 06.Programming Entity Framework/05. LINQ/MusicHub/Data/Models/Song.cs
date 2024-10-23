
namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using Enums;

using System.ComponentModel.DataAnnotations;

public class Song
{
    public Song()
    {
        SongPerformers = new HashSet<SongPerformer>();
    }
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.SongNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public Genre Genre { get; set; }

    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }

    public virtual Album Album { get; set; }  = null!;

    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }

    public virtual Writer Writer { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; }

}
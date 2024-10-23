namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.DataModelsValidationConstants.BlogConstants;

/// <summary>
/// Represents a blog post.
/// </summary>

public class Blog
{
    public Blog()
    {
        this.Id = Guid.NewGuid();
    }
    [Key]

    public Guid Id { get; init; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }

    public ApplicationUser Author { get; set; } = null!;

    [Required]
    [DisplayFormat(DataFormatString = DateFormat)]
    public DateTime CreatedOn { get; set; }

    [MaxLength(UrlMaxLength)]
    public string? ImageUrl { get; set; }

    [Required]
    [MaxLength(ContentMaxLength)]
    public string Content { get; set; } = null!;

    public int Likes { get; set; }

    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
}

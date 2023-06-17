namespace Library.Models.Book;

using Library.Models.Category;
using System.ComponentModel.DataAnnotations;

using static Library.Data.ValaditionConstants.Book;

public class BookFormModel
{
    public BookFormModel()
    {
        this.Categories = new List<CategoryViewModel>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    public string Url { get; set; } = null!;

    [Required]
    [Range(typeof(decimal), RatingMinValue, RatingMaxValue)]
    public decimal Rating { get; set; }

    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = null!;
}


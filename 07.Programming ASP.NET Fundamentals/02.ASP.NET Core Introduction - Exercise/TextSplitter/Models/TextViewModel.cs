using System.ComponentModel.DataAnnotations;

namespace TextSplitter.Models;

public class TextViewModel
{
    [Required]
    [StringLength(30,MinimumLength = 2)]
    public string Text { get; set; } = null!;

    public string SplitText { get; set; } = null!;
}
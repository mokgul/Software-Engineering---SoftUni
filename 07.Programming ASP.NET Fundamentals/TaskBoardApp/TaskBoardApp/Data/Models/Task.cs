namespace TaskBoardApp.Data.Models;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static TaskBoardApp.Data.DataConstants.Task;

public class Task
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Board))]
    public int BoardId { get; set; }

    public Board? Board { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public string OwnerId { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;
}


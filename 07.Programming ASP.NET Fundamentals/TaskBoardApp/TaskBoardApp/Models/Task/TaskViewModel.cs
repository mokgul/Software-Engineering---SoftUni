namespace TaskBoardApp.Models.Task;

using System.ComponentModel.DataAnnotations;

public class TaskViewModel
{
    public int Id { get; init; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public string Owner { get; set; } = null!;
}


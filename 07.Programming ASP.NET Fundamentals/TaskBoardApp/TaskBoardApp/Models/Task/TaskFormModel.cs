namespace TaskBoardApp.Models.Task;

using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstants.Task;

public class TaskFormModel
{
    public TaskFormModel()
    {
        this.Boards = new List<TaskBoardModel>();
    }

    [Required]
    [StringLength(TitleMaxLength, 
        MinimumLength = TitleMinLength,
        ErrorMessage = "Title should be at least {2} characters long.")]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, 
        MinimumLength = DescriptionMinLength, 
        ErrorMessage = "Description should be at least {2} characters long.")]
    public string Description { get; set; } = null!;

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
}


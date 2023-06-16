namespace TaskBoardApp.Models.Task;

public class TaskDetailsViewModel : TaskViewModel
{
    public string CreatedOn { get; set; } = null!;

    public string Board { get; set; } = null!;
}


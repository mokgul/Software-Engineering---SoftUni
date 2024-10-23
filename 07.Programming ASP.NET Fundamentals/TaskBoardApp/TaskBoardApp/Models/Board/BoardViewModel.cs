namespace TaskBoardApp.Models.Board;

using TaskBoardApp.Models.Task;

public class BoardViewModel
{

    public BoardViewModel()
    {
        this.Tasks = new List<TaskViewModel>();
    }
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public IEnumerable<TaskViewModel> Tasks { get; set; } = null!;
}


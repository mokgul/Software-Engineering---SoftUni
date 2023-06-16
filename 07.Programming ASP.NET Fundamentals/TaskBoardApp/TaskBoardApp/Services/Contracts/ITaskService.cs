namespace TaskBoardApp.Services.Contracts;

using TaskBoardApp.Models.Task;

public interface ITaskService
{
    Task CreateTaskAsync(TaskFormModel model, string userId);

    IEnumerable<TaskBoardModel> GetBoards();

    Task<TaskDetailsViewModel> GetTaskDetailsAsync(int id);

    Task<TaskFormModel> GetTaskByIdAsync(int id);

    Task<TaskViewModel> GetTaskByIdForDeleteAsync(int id);

    Task EditTaskAsync(int id, TaskFormModel model);

    Task DeleteTaskAsync(int id);
}


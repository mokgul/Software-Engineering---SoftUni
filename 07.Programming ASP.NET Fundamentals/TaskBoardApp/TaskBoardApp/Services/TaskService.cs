namespace TaskBoardApp.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Services.Contracts;

public class TaskService : ITaskService
{
    private readonly TaskBoardAppDbContext _context;

    public TaskService(TaskBoardAppDbContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task CreateTaskAsync(TaskFormModel model, string userId)
    {
        Data.Models.Task task = new Data.Models.Task()
        {
            Title = model.Title,
            Description = model.Description,
            CreatedOn = DateTime.Now,
            BoardId = model.BoardId,
            OwnerId = userId
        };
        
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<TaskBoardModel> GetBoards()
    {
        var boards = _context.Boards
            .Select(b => new TaskBoardModel
            {
                Id = b.Id,
                Name = b.Name,
            })
            .ToList();
        return boards;
    }

    public async Task<TaskDetailsViewModel> GetTaskDetailsAsync(int id)
    {
        var task = await _context.Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskDetailsViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                Board = t.Board.Name,
                Owner = t.User.UserName,
            })
            .FirstOrDefaultAsync();

        return task;
    }

    public async Task<TaskFormModel> GetTaskByIdAsync(int id)
    {
        var task = await _context.Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskFormModel
            {
                Title = t.Title,
                Description = t.Description,
                BoardId = t.BoardId
            })
            .FirstOrDefaultAsync();

        return task;
    }
    public async Task<TaskViewModel> GetTaskByIdForDeleteAsync(int id)
    {
        var task = await _context.Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Owner = t.User.UserName
            })
            .FirstOrDefaultAsync();

        return task;
    }

    public async Task EditTaskAsync(int id, TaskFormModel model)
    {
        var task = await _context.Tasks.FindAsync(id);



        if (task != null)
        {
            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }

}


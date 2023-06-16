namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Services.Contracts;

[Authorize]
public class TaskController : Controller
{
    private readonly TaskBoardAppDbContext _context;

    private readonly ITaskService _taskService;

    public TaskController(TaskBoardAppDbContext data, ITaskService taskService)
    {
        _context = data;
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        TaskFormModel model = new TaskFormModel()
        { 
            Boards = _taskService.GetBoards()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel model)
    {
        if(!_taskService.GetBoards().Any(b => b.Id == model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
        }

        string currentUserId = GetUserId();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _taskService.CreateTaskAsync(model, currentUserId);

        }
        catch
        {
            BadRequest();
        }


        return RedirectToAction("All", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var task = await _taskService.GetTaskDetailsAsync(id);

        if (task == null) return NotFound();

        return View(task);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        var owner = await _context.Tasks.FindAsync(id);

        if (task == null) return NotFound();

        string currentUserId = GetUserId();

        if(currentUserId != owner.OwnerId)
        {
            return Unauthorized();
        }
        task.Boards = _taskService.GetBoards();
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TaskFormModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Boards = _taskService.GetBoards();
            return View(model);
        }

        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null) return NotFound();

        string currentUserId = GetUserId();

        var owner = await _context.Tasks.FindAsync(id);

        if (currentUserId != owner.OwnerId)
        {
            return Unauthorized();
        }

        if(!_taskService.GetBoards().Any(b => b.Id == model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board does not exist");
        }

        try
        {
            await _taskService.EditTaskAsync(id, model);
        }
        catch
        {
            BadRequest();
        }

        return RedirectToAction("All", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskService.GetTaskByIdForDeleteAsync(id);
        var owner = await _context.Tasks.FindAsync(id);

        if (task == null) return NotFound();

        string currentUserId = GetUserId();

        if (currentUserId != owner.OwnerId)
        {
            return Unauthorized();
        }
       
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel model)
    {
        var task = await _taskService.GetTaskByIdForDeleteAsync(model.Id);
        var owner = await _context.Tasks.FindAsync(model.Id);
        if (task == null)
        {
            return NotFound();
        }

        string currentUserId = GetUserId();
        if(currentUserId != owner.OwnerId)
        {
            return Unauthorized();
        }
        await _taskService.DeleteTaskAsync(task.Id);
        return RedirectToAction("All", "Board");
    }

    public IActionResult Index()
    {
        return View();
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}


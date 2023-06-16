namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using TaskBoardApp.Data;
using TaskBoardApp.Models;

public class HomeController : Controller
{
    private readonly TaskBoardAppDbContext _context;

    public HomeController(TaskBoardAppDbContext data)
    {
        _context = data;
    }

    public IActionResult Index()
    {
        var taskBoards = _context
            .Boards
            .Select(b => b.Name)
            .Distinct();

        var tasksCount = new List<HomeBoardModel>();
        foreach (var boardName in taskBoards)
        {
            // var tasksInBoard = _context.Tasks.Where(t => t.Board.Name == boardName).Count();
            tasksCount.Add(new HomeBoardModel { BoardName = boardName, TasksCount = new Random().Next(0, 20) });
        }

        var userTasksCount = -1;

        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userTasksCount = _context.Tasks.Where(t => t.OwnerId == userId).Count();
        }

        var homeModel = new HomeViewModel()
        {
            AllTasksCount = _context.Tasks.Count(),
            BoardsWithTasksCount = tasksCount,
            UserTasksCount = userTasksCount
        };

        return View(homeModel);
    }
}

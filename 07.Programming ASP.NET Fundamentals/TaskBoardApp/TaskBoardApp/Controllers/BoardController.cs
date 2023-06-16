namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Mvc;

using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;

public class BoardController : Controller
{
    private readonly TaskBoardAppDbContext _context;
    private readonly IBoardService _boardService;

    public BoardController(TaskBoardAppDbContext data, IBoardService boardService)
    {
        _context = data;
        _boardService = boardService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> All()
    {
        var boards = await _boardService.GetAllAsync();
        return View(boards);
    }
}


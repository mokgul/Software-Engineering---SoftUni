namespace TaskBoardApp.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Services.Contracts;

public class BoardService : IBoardService
{
    private readonly TaskBoardAppDbContext _context;

    public BoardService(TaskBoardAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<BoardViewModel>> GetAllAsync()
    {
        var boards = await _context.Boards
            .Select(b => new BoardViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks.Select(t => new TaskViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.User.UserName
                })
            })
            .ToListAsync();
        return boards;
    }
}


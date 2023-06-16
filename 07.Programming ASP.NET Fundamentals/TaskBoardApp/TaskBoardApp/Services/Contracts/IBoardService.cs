namespace TaskBoardApp.Services.Contracts;

using TaskBoardApp.Models.Board;

public interface IBoardService
{
    Task<IEnumerable<BoardViewModel>> GetAllAsync();
}


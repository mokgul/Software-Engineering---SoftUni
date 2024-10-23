namespace TaskBoardApp.Data.Models;

using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Data.DataConstants.Board;

public class Board
{
    public Board()
    {
        this.Tasks = new List<Task>();
    }

    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public IEnumerable<Task> Tasks { get; set; }
}


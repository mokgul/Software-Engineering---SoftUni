namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GameTag
{
    [Key]
    public virtual Game Game { get; set; }

    [Required]
    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    [Key]
    public virtual Tag Tag { get; set; }

    [Required]
    [ForeignKey(nameof(Tag))]
    public int TagId { get; set; }
}
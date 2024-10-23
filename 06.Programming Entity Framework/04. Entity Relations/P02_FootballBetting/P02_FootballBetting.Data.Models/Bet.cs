namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enum;


public class Bet
{
    [Key]
    public int BetId { get; set; }

    public decimal Amount { get; set; }

    public Prediction Prediction { get; set; }

    public DateTime DateTime { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public Game Game { get; set; } = null!;

}

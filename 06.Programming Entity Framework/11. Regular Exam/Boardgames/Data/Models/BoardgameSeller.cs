namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BoardgameSeller
{
    public Boardgame Boardgame { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Boardgame))]
    public int BoardgameId { get; set; }

    public Seller Seller { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Seller))]
    public int SellerId { get; set; }

}
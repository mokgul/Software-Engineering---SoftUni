namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game
{
    public Game()
    {
        this.Purchases = new HashSet<Purchase>();
        this.GameTags = new HashSet<GameTag>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public virtual Developer Developer { get; set; }

    [Required]
    [ForeignKey(nameof(Developer))]
    public int DeveloperId { get; set; }

    [Required]
    public virtual Genre Genre { get; set; }

    [Required]
    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; }

    public virtual ICollection<GameTag> GameTags { get; set; }

}
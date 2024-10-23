namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;


public class Card
{
    public Card()
    {
        this.Purchases = new HashSet<Purchase>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    public string Number { get; set; }

    [Required]
    public string Cvc { get; set; }

    [Required]
    public CardType Type { get; set; }

    [Required]
    public virtual User User { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; }

}
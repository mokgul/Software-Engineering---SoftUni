namespace SoftJail.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Mail
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Sender { get; set; }

    [Required]
    public string Address { get; set; }

    public virtual Prisoner Prisoner { get; set; }

    [ForeignKey(nameof(Prisoner))]
    public int PrisonerId { get; set; }
}
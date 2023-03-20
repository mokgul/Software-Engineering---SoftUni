namespace SoftJail.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OfficerPrisoner
{
    [Key]
    public virtual Prisoner Prisoner { get; set; } = null!;

    [ForeignKey(nameof(Prisoner))]
    public int PrisonerId { get; set; }

    [Key]
    public virtual Officer Officer { get; set; } = null!;

    [ForeignKey(nameof(Officer))]
    public int OfficerId { get; set; }

}
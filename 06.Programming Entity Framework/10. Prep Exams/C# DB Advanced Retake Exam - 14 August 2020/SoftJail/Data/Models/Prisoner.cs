namespace SoftJail.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Prisoner
{
    public Prisoner()
    {
        Mails = new HashSet<Mail>();
        PrisonerOfficers = new HashSet<OfficerPrisoner>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Nickname { get; set; }

    public int Age { get; set; }

    public DateTime IncarcerationDate { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public decimal? Bail { get; set; }

    public virtual Cell Cell { get; set; }
   
    [ForeignKey(nameof(Cell))]
    public int? CellId { get; set; }

    public virtual ICollection<Mail> Mails { get; set; }
    public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }

}
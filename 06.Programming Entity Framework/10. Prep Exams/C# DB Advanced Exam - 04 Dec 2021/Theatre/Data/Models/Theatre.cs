namespace Theatre.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Theatre
{
    public Theatre()
    {
        Tickets = new HashSet<Ticket>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public sbyte NumberOfHalls { get; set; }

    [Required]
    public string Director { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }

}
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Play
{
    public Play()
    {
        this.Casts = new HashSet<Cast>();
        this.Tickets = new HashSet<Ticket>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    public float Rating { get; set; }

    [Required]
    public Genre Genre { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Screenwriter { get; set; }

    public virtual ICollection<Cast> Casts { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }

}
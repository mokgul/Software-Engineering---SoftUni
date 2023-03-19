namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Despatcher
{
    public Despatcher()
    {
        Trucks = new HashSet<Truck>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Position { get; set; }

    public virtual ICollection<Truck> Trucks { get; set; }  = null!;
}
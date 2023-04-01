namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Manufacturer
{
    public Manufacturer()
    {
        this.Guns = new HashSet<Gun>();
    }

    [Key]
    public int Id { get; set; }

    [Required] 
    public string ManufacturerName { get; set; } = null!;

    [Required]
    public string Founded { get; set; } = null!;

    public virtual ICollection<Gun> Guns { get; set; }

}
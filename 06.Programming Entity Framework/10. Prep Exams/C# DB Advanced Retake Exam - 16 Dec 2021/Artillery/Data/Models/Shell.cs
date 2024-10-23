namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Shell
{
    public Shell()
    {
        this.Guns = new HashSet<Gun>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public double ShellWeight { get; set; }

    [Required]
    public string Caliber { get; set; } = null!;

    public virtual ICollection<Gun> Guns { get; set; }

}
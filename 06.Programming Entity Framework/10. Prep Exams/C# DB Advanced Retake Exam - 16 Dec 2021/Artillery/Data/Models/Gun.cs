namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Gun
{
    public Gun()
    {
        this.CountriesGuns = new HashSet<CountryGun>();
    }

    [Key]
    public int Id { get; set; }

    public Manufacturer Manufacturer { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Manufacturer))]
    public int ManufacturerId { get; set;}

    [Required]
    public int GunWeight { get; set; }

    [Required]
    public double BarrelLength { get; set; }

    public int? NumberBuild { get; set; }

    [Required]
    public int Range { get; set; }

    [Required]
    public GunType GunType { get; set; }

    public Shell Shell { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Shell))]
    public int ShellId { get; set; }

    public virtual ICollection<CountryGun> CountriesGuns { get; set; }

}
namespace Artillery.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CountryGun
{
    public Country Country { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }

    public Gun Gun { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Gun))]
    public int GunId { get; set; }

}
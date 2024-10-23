namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Truck
{
    public Truck()
    {
        this.ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    [Required]
    public string VinNumber { get; set;} = null!;

    public int TankCapacity { get; set; }

    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    public Despatcher Despatcher { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set;}

    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; } = null!;

}
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models;

public class ClientTruck
{
    public Client Client { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    public Truck Truck { get; set; } = null!;

    [ForeignKey(nameof(Truck))]
    public int TruckId { get; set; }

}
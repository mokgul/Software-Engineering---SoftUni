using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;

namespace Trucks.DataProcessor;

using Data;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        var despatchers = context.Despatchers
            .Where(d => d.Trucks.Any())
            .ToArray()
            .Select(d => new ExportDespatchersWithTheirTrucksDto()
            {
                TrucksCount = d.Trucks.Count(),
                DespatcherName = d.Name,
                Trucks = d.Trucks
                    .Select(t => new TruckXmlDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
            })
            .OrderByDescending(d => d.TrucksCount)
            .ThenBy(d => d.DespatcherName)
            .ToArray();

        return Serialize<ExportDespatchersWithTheirTrucksDto[]>(despatchers, "Despatchers");
    }

    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var clients = context.Clients
            .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
            .ToArray()
            .Select(c => new ExportClientsWithMostTrucksDto()
            {
                ClientName = c.Name,
                Trucks = c.ClientsTrucks
                    .Where(t => t.Truck.TankCapacity >= capacity)
                    .Select(t => new TruckJsonDto()
                    {
                        RegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber = t.Truck.VinNumber,
                        TankCapacity = t.Truck.TankCapacity,
                        CargoCapacity = t.Truck.CargoCapacity,
                        CategoryType = t.Truck.CategoryType.ToString(),
                        MakeType = t.Truck.MakeType.ToString(),
                    })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
                    .ToArray()
            })
            .OrderByDescending(c =>c.Trucks.Count())
            .ThenBy(c => c.ClientName)
            .Take(10)
            .ToArray();
            
        return JsonConvert.SerializeObject(clients, Formatting.Indented);
    }

    private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

        StringBuilder sb = new StringBuilder();
        using var write = new StringWriter(sb);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

        return sb.ToString();
    }
}


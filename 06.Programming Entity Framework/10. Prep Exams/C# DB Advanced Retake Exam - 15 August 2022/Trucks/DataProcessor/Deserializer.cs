namespace Trucks.DataProcessor;

using System.Text;
using System.Xml.Serialization;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        ImportDispatchersDto[] dispatchers = Deserialize<ImportDispatchersDto[]>(xmlString, "Despatchers");
        
        StringBuilder sb  = new StringBuilder();

        foreach (var person in dispatchers)
        {
            if (!IsValid(person))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (string.IsNullOrEmpty(person.Position))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Despatcher despatcher = new Despatcher(){Name = person.Name, Position = person.Position};
           
            foreach (var truck in person.Trucks)
            {
                if (!IsValid(truck))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Truck current = new Truck()
                {
                    RegistrationNumber = truck.RegistrationNumber,
                    VinNumber = truck.VinNumber,
                    TankCapacity = truck.TankCapacity,
                    CargoCapacity = truck.CargoCapacity,
                    CategoryType = Enum.Parse<CategoryType>(truck.CategoryType.ToString()),
                    MakeType = Enum.Parse<MakeType>(truck.MakeType.ToString())
                };
                despatcher.Trucks.Add(current);
            }
            context.Despatchers.Add(despatcher);
            context.SaveChanges();
            
            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher,despatcher.Name, despatcher.Trucks.Count()));
        }
       
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        ImportClientsDto[] clients = JsonConvert.DeserializeObject<ImportClientsDto[]>(jsonString)!;

        StringBuilder sb = new StringBuilder();

        foreach (var client in clients)
        {
            if(!IsValid(client) || string.IsNullOrEmpty(client.Nationality) || client.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Client current = new Client() { Name = client.Name, Nationality = client.Nationality, Type = client.Type };

            foreach (var id in client.TruckIds.Distinct())
            {
                if(!context.Trucks.Any( t => t.Id == id))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ClientTruck currentMap = new ClientTruck()
                {
                    Client = current,
                    ClientId = current.Id,
                    Truck = context.Trucks.First(t => t.Id == id),
                    TruckId = context.Trucks.First(t => t.Id == id).Id,
                };
                current.ClientsTrucks.Add(currentMap);
            }
            context.Clients.Add(current);
            context.SaveChanges();
            sb.AppendLine(string.Format(SuccessfullyImportedClient, current.Name, current.ClientsTrucks.Count));
        }

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
    private static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(inputXml);

        T dtos = (T)serializer.Deserialize(reader);
        return dtos;
    }
}

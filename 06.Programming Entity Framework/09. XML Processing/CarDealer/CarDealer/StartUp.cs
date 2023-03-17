using System.Xml.Linq;
using System.Xml.Serialization;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

using Data;
using System.Diagnostics.Metrics;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // I. Import Data

        // Q9. Import Supplies
        string xmlSupplies = File.ReadAllText(@"../../../Datasets/suppliers.xml");
        ImportSuppliers(context, xmlSupplies);

        // Q10. Import Parts
        string xmlParts = File.ReadAllText(@"../../../Datasets/parts.xml");
        ImportParts(context, xmlParts);

        // Q11. Import Cars
        string xmlCars = File.ReadAllText(@"../../../Datasets/cars.xml");
        ImportCars(context, xmlCars);

        // Q12. Import Customers
        string xmlCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
        ImportCustomers(context, xmlCustomers);

        // Q13. Import Sales
        string xmlSales = File.ReadAllText(@"../../../Datasets/sales.xml");
        ImportSales(context, xmlSales);
        
    }

    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        int[] carIds = context.Cars.Select(i => i.Id).ToArray();
        XDocument document = XDocument.Parse(inputXml);

        var sales = document.Root!.Elements();
       
        foreach (var item in sales)
        {
            int carId = int.Parse(item.Element("carId")!.Value);
            if(!carIds.Contains(carId)) continue;
            Sale sale = new Sale()
            {
                CarId = int.Parse(item.Element("carId")!.Value),
                CustomerId = int.Parse(item.Element("customerId")!.Value),
                Discount = decimal.Parse(item.Element("discount")!.Value),
            };

            context.Sales.Add(sale);
        }
        context.SaveChanges();
        return $"Successfully imported {context.Sales.Count()}";
    }

    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        XDocument document = XDocument.Parse(inputXml);

        var customers = document.Root!.Elements();
       
        foreach (var item in customers)
        {
            
            Customer customer = new Customer()
            {
                Name = item.Element("name")!.Value,
                BirthDate = DateTime.Parse(item.Element("birthDate")!.Value),
                IsYoungDriver = bool.Parse(item.Element("isYoungDriver")!.Value),
            };

            context.Customers.Add(customer);
        }
        context.SaveChanges();
        return $"Successfully imported {customers.Count()}";
    }

    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var cars = xmlDocument.Root.Elements();

        List<Car> carsX = new List<Car>();
        List<PartCar> partsX = new List<PartCar>();

        int carId = 1;

        int[] partInts = context.Parts.Select(p => p.Id).ToArray();
        var partIds = xmlDocument.Descendants("partId").Select(p => p.Attribute("id").Value);

        foreach (var car in cars)
        {
            Car c = new Car()
            {
                Make = car.Element("make").Value,
                Model = car.Element("model").Value,
                TraveledDistance = long.Parse(car.Element("traveledDistance").Value)
                //TraveledDistance = long.Parse(car.Element("TraveledDistance").Value)
                //For Judge use commented line
            };

            carsX.Add(c);

            foreach (var partId in car.Descendants("partId")
                         .Where(p => partIds.Contains(p.Attribute("id").Value))
                         .Select(p => p.Attribute("id").Value).Distinct())
            {
                PartCar partCar = new PartCar()
                {
                    CarId = carId,
                    Car = c,
                    PartId = int.Parse(partId)
                };

                partsX.Add(partCar);
            }

            carId++;
        }

        context.AddRange(carsX);
        context.AddRange(partsX);

        context.SaveChanges();

        return $"Successfully imported {carsX.Count}";
    }


    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        XDocument document = XDocument.Parse(inputXml);

        var parts = document.Root!.Elements();
        int counter = 0;
        foreach (var item in parts)
        {
            int supplier = int.Parse(item.Element("supplierId")!.Value);

            if(supplier > context.Suppliers.Count()) continue;
            Part part = new Part()
            {
                Name = item.Element("name")!.Value,
                Price = decimal.Parse(item.Element("price")!.Value),
                Quantity = int.Parse(item.Element("quantity")!.Value),
                SupplierId = int.Parse(item.Element("supplierId")!.Value)
            };

            context.Parts.Add(part);
            counter++;
        }

        context.SaveChanges();
        return $"Successfully imported {counter}";
    }
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        XDocument document = XDocument.Parse(inputXml);

        var suppliers = document.Root!.Elements();

        foreach (var item in suppliers)
        {
            Supplier supplier = new Supplier()
            {
                Name = item.Element("name")!.Value,
                IsImporter = bool.Parse(item.Element("isImporter")!.Value)
            };

            context.Suppliers.Add(supplier);
        }

        context.SaveChanges();
        return $"Successfully imported {suppliers.Count()}";
    }

    private static T Deserializer<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(inputXml);

        T dtos = (T)serializer.Deserialize(reader);
        return dtos;
    }
}



using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using System.Xml.Serialization;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

using Data;
using System.Diagnostics.Metrics;
using System.Text;

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

        // Q14. Export Cars With Distance
        string xmlCarsWithDistance = GetCarsWithDistance(context);
        File.WriteAllText(@"../../../Results/cars.xml", GetCarsWithDistance(context));

        // Q15. Export Cars from Make BMW
        string xmlCarsFromMake = GetCarsFromMakeBmw(context);
        File.WriteAllText(@"../../../Results/bmw-cars.xml", GetCarsFromMakeBmw(context));

        // Q16. Export Local Suppliers
        string xmlLocalSuppliers = GetLocalSuppliers(context);
        File.WriteAllText(@"../../../Results/local-suppliers.xml", GetLocalSuppliers(context));

        // Q17. Export Cars with Their List of Parts
        string xmlCarsWithParts = GetCarsWithTheirListOfParts(context);
        File.WriteAllText(@"../../../Results/cars-and-parts.xml", GetCarsWithTheirListOfParts(context));

        // Q18. Export Total Sales by Customer 
        string xmlSalesByCustomer = GetTotalSalesByCustomer(context);
        File.WriteAllText(@"../../../Results/customers-total-sales.xml", GetTotalSalesByCustomer(context));

        // Q19. Export Sales with Applied Discount
        string xmlSaleswithAppliedDiscout = GetSalesWithAppliedDiscount(context);
        File.WriteAllText(@"../../../Results/sales-discounts.xml", GetSalesWithAppliedDiscount(context));

    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 1681")]
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Select(s => new ExportSalesWithDiscountDto()
            {
                CarSalesNoDiscountDto = new CarSalesNoDiscountDto()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    Distance = s.Car.TraveledDistance
                },
                Discount = (int)s.Discount,
                CustomerName = s.Customer.Name,
                Price = Math.Round(s.Car.PartsCars.Sum(p => p.Part.Price), 2),
                PriceWithDiscount = (double) Math.Round((s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
            })
            .ToArray();

        return Serializer<ExportSalesWithDiscountDto[]>(sales, "sales");
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 713")]
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customers = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count(),
                moneyCars = c.IsYoungDriver
                ? c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price * 0.95m, 2)))
                : c.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price, 2)))
            })
            .ToArray();

        var output = customers
            .Select(o => new ExportTotalSalesByCustomerDto
            {
                FullName = o.fullName,
                BoughtCars = o.boughtCars,
                SpentMoney = o.moneyCars.Sum()
            })
            .OrderByDescending(o => o.SpentMoney)
            .ToArray();

        return Serializer<ExportTotalSalesByCustomerDto[]>(output, "customers");
    }
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithParts = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .Select(c => new ExportCarsWithTheirPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                Distance = c.TraveledDistance,
                Parts = c.PartsCars
                    .Select(p => new CarPartDto()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
            })
            .ToArray();

        return Serializer<ExportCarsWithTheirPartsDto[]>(carsWithParts, "cars");
    }

    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .Select(s => new ExportLocalSuppliersDto()
            {
                Id = s.Id,
                Name = s.Name,
                Count = s.Parts.Count,
            })
            .ToArray();

        return Serializer<ExportLocalSuppliersDto[]>(suppliers, "suppliers");
    }

    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var bmwCars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(x => new ExportBmwCarsDto()
            {
                Id = x.Id,
                Model = x.Model,
                Distance = x.TraveledDistance
            })
            .ToArray();

        return Serializer<ExportBmwCarsDto[]>(bmwCars, "cars");
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 441")]
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var cars = context.Cars
            .Where(d => d.TraveledDistance > 2000000)
            .OrderBy(m => m.Make)
            .ThenBy(m => m.Model)
            .Select(c => new ExportCarsWithDistanceDto()
            {
                Make = c.Make,
                Model = c.Model,
                Distance = c.TraveledDistance
            })
            .Take(10)
            .ToArray();

        return Serializer(cars, "cars");
    }

    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        int[] carIds = context.Cars.Select(i => i.Id).ToArray();
        XDocument document = XDocument.Parse(inputXml);

        var sales = document.Root!.Elements();

        foreach (var item in sales)
        {
            int carId = int.Parse(item.Element("carId")!.Value);
            if (!carIds.Contains(carId)) continue;
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

            if (supplier > context.Suppliers.Count()) continue;
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

    private static string Serializer<T>(T dataTransferObjects, string xmlRootAttributeName)
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


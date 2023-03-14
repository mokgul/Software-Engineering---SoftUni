using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace CarDealer;

using CarDealer.DTOs.Import;
using Data;
using Models;
using Newtonsoft.Json;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // 02. Import Data

        // Q9. Import Suppliers
        string jsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
        ImportSuppliers(context, jsonSuppliers);

        // Q10. Import Parts
        string jsonParts = File.ReadAllText(@"../../../Datasets/parts.json");
        ImportParts(context, jsonParts);

        // Q11. Import Cars
        string jsonCars = File.ReadAllText(@"../../../Datasets/cars.json");
        ImportCars(context, jsonCars);

        // Q12. Import Customers
        string jsonCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
        ImportCustomers(context, jsonCustomers);

        // Q13. Import Sales
        string jsonSales = File.ReadAllText(@"../../../Datasets/sales.json");
        ImportSales(context, jsonSales);

        // Q14. Export Ordered Customers
        //File.WriteAllText(@"../../../Results/ordered-customers.json", GetOrderedCustomers(context));
        //Console.WriteLine(GetOrderedCustomers(context));

        // Q15. Export Cars from Make Toyota
        //File.WriteAllText(@"../../../Results/toyota-cars.json", GetCarsFromMakeToyota(context));
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        // Q16. Export Local Suppliers
        //File.WriteAllText(@"../../../Results/local-suppliers.json", GetLocalSuppliers(context));
        //Console.WriteLine(GetLocalSuppliers(context));

        // Q17. Export Cars with Their List of Parts
        //File.WriteAllText(@"../../../Results/cars-and-parts.json", GetCarsWithTheirListOfParts(context));
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        // Q18. Export Total Sales by Customer
        //File.WriteAllText(@"../../../Results/customers-total-sales.json", GetTotalSalesByCustomer(context));
        //Console.WriteLine(GetTotalSalesByCustomer(context));

        // Q19. Export Sales With Applied Discount
        File.WriteAllText(@"../../../Results/sales-discounts.json", GetSalesWithAppliedDiscount(context));
        Console.WriteLine(GetSalesWithAppliedDiscount(context));
    }

    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        List<int> suppliersIds = context.Suppliers
            .Select(x => x.Id).ToList();
        List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)!
            .Where(s => suppliersIds.Contains(s.SupplierId))
            .ToList();

        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }
    public static string ImportCars(CarDealerContext context, string inputJson)
    {

        List<CarDto> carsDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

        List<Car> cars = new List<Car>();
        List<PartCar> parts = new List<PartCar>();

        foreach (var carDto in carsDtos)
        {
            Car car = new Car()
            {
                Make = carDto.Make,
                Model = carDto.Model,
                TraveledDistance = carDto.TravelledDistance
            };

            cars.Add(car);

            foreach (var carPart in carDto.PartIds.Distinct())
            {
                PartCar partCar = new PartCar()
                {
                    Car = car,
                    PartId = carPart
                };

                parts.Add(partCar);
            }
        }

        context.AddRange(cars);
        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson)!;

        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson)!;

        context.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson)!;

        context.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(b => b.BirthDate)
            .ThenBy(y => y.IsYoungDriver)
            .Select(c => new
            {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                IsYoungDriver = c.IsYoungDriver,
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 136")]
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var cars = context.Cars
            .Where(c => c.Make == "Toyota")
            .Select(c => new
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(m => m.Model)
            .ThenByDescending(t => t.TraveledDistance)
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }

    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(a => !a.IsImporter)
            .Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 4253")]
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cars = context.Cars
            .Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance

                },
                parts = c.PartsCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("0.00"),
                    })
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }

    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var salesIds = context.Sales.Select(s => s.CustomerId).ToList();

        var customers = context.Customers
            .Where(c => salesIds.Contains(c.Id))
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count,
                moneyCars = c.Sales.SelectMany(c => c.Car.PartsCars.Select(p => p.Part.Price))
            })
            .AsNoTracking()
            .ToArray();

        var output = customers
            .Select(o => new
            {
                o.fullName,
                o.boughtCars,
                spentMoney = o.moneyCars.Sum()
            })
            .OrderByDescending(x => x.spentMoney)
            .ThenByDescending(g => g.boughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(output, Formatting.Indented);
    }

    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Take(10)
            .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = s.Discount.ToString("0.00"),
                price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("0.00"),
                priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))).ToString("0.00")
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(sales, Formatting.Indented);
    }
}

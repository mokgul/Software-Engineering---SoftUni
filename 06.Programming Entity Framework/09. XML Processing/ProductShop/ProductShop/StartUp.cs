using System.Xml;
using System.Xml.Linq;
using ProductShop.Models;

namespace ProductShop;

using Data;
using ProductShop.DTOs.Export;
using System.Text;
using System.Xml.Serialization;

public class StartUp
{
    public static void Main()
    {
        // I.Setup
        ProductShopContext context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // II. Import Data

        // Q1. Import Users
        var usersXml = File.ReadAllText(@"../../../Datasets/users.xml");
        ImportUsers(context, usersXml);

        // Q2. Import Products
        string productsXml = File.ReadAllText(@"../../../Datasets/products.xml");
        ImportProducts(context, productsXml);

        // Q3.Import Categories
        string categoriesXml = File.ReadAllText(@"../../../Datasets/categories.xml");
        ImportCategories(context, categoriesXml);

        // Q4. Import Categories and Products
        string ctprXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
        ImportCategoryProducts(context, ctprXml);

        // III. Query and Export Data

        // Q5. Export Products in Range
        string xmlProducts = GetProductsInRange(context);
        File.WriteAllText(@"../../../results/products-in-range.xml", GetProductsInRange(context));

        // Q6.Export Sold Products
        string xmlSoldProducts = GetSoldProducts(context);
        File.WriteAllText(@"../../../results/users-sold-products.xml", GetSoldProducts(context));
    }

    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        var map = XDocument.Parse(inputXml).Root!.Elements();

        foreach (var item in map)
        {
            CategoryProduct cp = new CategoryProduct()
            {
                CategoryId = int.Parse(item.Element("CategoryId")!.Value),
                ProductId = int.Parse(item.Element("ProductId")!.Value)
            };
            context.CategoryProducts.Add(cp);
        }
        context.SaveChanges();

        return $"Successfully imported {map.Count()}";
    }

    public static string ImportCategories(ProductShopContext context, string categoriesXml)
    {

        var categories = XDocument.Parse(categoriesXml).Root!.Elements();

        foreach (var ct in categories)
        {
            Category c = new Category()
            {
                Name = ct.Element("name")!.Value
            };
            context.Categories.Add(c);
        }

        context.SaveChanges();

        return $"Successfully imported {categories.Count()}";
    }

    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        XDocument usersXml = XDocument.Parse(inputXml);
        var users = usersXml.Root!.Elements();

        foreach (var user in users)
        {
            User u = new User()
            {
                FirstName = user.Element("firstName")!.Value,
                LastName = user.Element("lastName")!.Value,
                Age = int.Parse(user.Element("age").Value)
            };

            context.Users.Add(u);
        }
        context.SaveChanges();

        return $"Successfully imported {users.Count()}";
    }

    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        XDocument productXml = XDocument.Parse(inputXml);
        var products = productXml.Root!.Elements();

        foreach (var pr in products)
        {
            Product u = new Product()
            {
                Name = pr.Element("name")!.Value,
                Price = decimal.Parse(pr.Element("price")!.Value),
                SellerId = int.Parse(pr.Element("sellerId")!.Value),
                BuyerId = pr.Elements().Count() > 3
                ? int.Parse(pr.Element("buyerId")!.Value) : null
            };

            context.Products.Add(u);
        }
        context.SaveChanges();

        return $"Successfully imported {products.Count()}";
    }

    public static string GetProductsInRange(ProductShopContext context)
    {
        var productsInRange = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .Select(p => new ExportProductsInRangeDto()
            {
                Price = p.Price,
                Name = p.Name,
                Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
            })
            .ToArray();

        return Serializer<ExportProductsInRangeDto[]>(productsInRange, "Products");

    }

    public static string GetSoldProducts(ProductShopContext context)
    {
        var products = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .Select(u => new ExportSoldProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Products = u.ProductsSold
                    .Select(p => new ProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
            })
            .ToArray();

        return Serializer<ExportSoldProductsDto[]>(products, "Users");

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

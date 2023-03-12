using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 139")]
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //01.Import Data

            //Q1. Import Users
            string jsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
            ImportUsers(context, jsonUsers);

            //Q2. Import Products
            string jsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
            ImportProducts(context, jsonProducts);

            //Q3. Import Categories
            string jsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
            ImportCategories(context, jsonCategories);

            //Q4. Import Categories and Products
            string jsonCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");
            ImportCategoryProducts(context, jsonCategoryProducts);

            //02.Export Data

            //Q5. Export Products in Range
            //File.WriteAllText("../../../Results/products-in-range.json",GetProductsInRange(context));
            //Console.WriteLine(GetProductsInRange(context));

            //Q6. Export Sold Products
            //File.WriteAllText(@"../../../Results/users-sold-products.json",GetSoldProducts(context));
            //Console.WriteLine(GetSoldProducts(context));

            //Q7. Export Categories by Products Count
            File.WriteAllText(@"../../../Results/categories-by-products.json",GetCategoriesByProductsCount(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count(),
                    averagePrice = Math.Round((double)c.CategoriesProducts.Average(p => p.Product.Price), 2),
                    totalRevenue = Math.Round((double)c.CategoriesProducts.Sum(p => p.Product.Price), 2)
                })
                .OrderByDescending(c => c.productsCount)
                //.ThenByDescending(c => c.averagePrice)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 1279")]
        [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 1623")]
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                .Select(p => new
                {
                    firstName = p.FirstName,
                    lastName = p.LastName,
                    soldProducts = p.ProductsSold
                        .Select(i => new
                        {
                            name = i.Name,
                            price = i.Price,
                            buyerFirstName = i.Buyer.FirstName,
                            buyerLastName = i.Buyer.LastName,
                        })
                })
                .OrderBy(s => s.lastName)
                .ThenBy(s => s.firstName)
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.price)
                .AsNoTracking()
                .ToList();
            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson)!;

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string jsonCategories)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories)!
                .Where(c => c.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson)!;
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson)!;

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
    }
}
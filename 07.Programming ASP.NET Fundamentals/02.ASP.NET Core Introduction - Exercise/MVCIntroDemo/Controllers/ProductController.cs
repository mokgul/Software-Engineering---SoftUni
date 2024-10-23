using System.Text;
using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models.Product;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using static MVCIntroDemo.Seeding.ProductsData;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        [ActionName("My-Products")]
        public IActionResult All(string keyword = "")
        {
            if (String.IsNullOrEmpty(keyword))
                return View(_products);

            IEnumerable<ProductViewModel> filteredProducts =
                _products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToArray();
            return View(filteredProducts);
        }

        public IActionResult ById(int id)
        {
            ProductViewModel? product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.RedirectToAction("My-Products");
            }
            return View(product);

        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Json(_products, options);
        }

        public IActionResult AllAsText()
        {
            var text = string.Empty;
            foreach (var item in _products)
            {
                text += $"Product {item.Id}: {item.Name} - {item.Price} lv.";
                text += "\r\n";
            }

            return Content(text);
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _products)
                sb.AppendLine($"Product: {item.Id}: {item.Name} - {item.Price:f2} lv.");

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}

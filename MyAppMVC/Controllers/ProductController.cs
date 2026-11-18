using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Data;
using MyAppMVC.Models;

namespace MyAppMVC.Controllers
{
    // Doi route /Product thanh /san-pham
    [Route("san-pham")]
    public class ProductController : Controller
    {
        // /san-pham                      -> tat ca san pham
        // /san-pham/danh-muc/1           -> san pham theo danh muc
        [HttpGet("")]
        [HttpGet("danh-muc/{categoryId:int}")]
        public IActionResult Index(int? categoryId)
        {
            List<Category> categories = SampleData.GetCategories();
            List<Product> products = SampleData.GetProducts();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.CurrentCategoryId = categoryId;
            return View(products);
        }

        // /san-pham/chi-tiet/1
        [HttpGet("chi-tiet/{id:int}")]
        public IActionResult Detail(int id)
        {
            var product = SampleData.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}

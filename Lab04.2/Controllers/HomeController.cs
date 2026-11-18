using DemoLab.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoLab.Controllers
{
    public class HomeController : Controller
    {
        // Phan "San pham moi nhat"
        public IActionResult Index()
        {
            var newProducts = SampleData.GetNewProducts(3);
            return View(newProducts);
        }

        public IActionResult About() => View();
        public IActionResult Contact() => View();
    }
}

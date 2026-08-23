using Microsoft.AspNetCore.Mvc;

namespace MyAppMVC.Controllers
{
    public class DemoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

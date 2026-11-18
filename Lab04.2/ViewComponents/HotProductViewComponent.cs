using DemoLab.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoLab.ViewComponents
{
    // Component HotProduct: goi bang  @await Component.InvokeAsync("HotProduct")
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int take = 3)
        {
            var products = SampleData.GetHotProducts(take);
            return View(products);   // Views/Shared/Components/HotProduct/Default.cshtml
        }
    }
}

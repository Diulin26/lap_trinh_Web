using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        SchoolContext db;
        List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }

        // ajax = false: link <a> gọi action Index (đồng bộ)
        // ajax = true : chỉ render <li id="MajorID">, việc lọc do jQuery AJAX xử lý
        public async Task<IViewComponentResult> InvokeAsync(bool ajax = false)
        {
            return View(ajax ? "RenderMajorAjax" : "RenderMajor", majors);
        }
    }
}

using LeThiDieuLinh_241230775.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LeThiDieuLinh_241230775.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _db;
        public HomeController(QLHangHoaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ds = _db.HangHoas
                .Where(h => h.Gia >= 100 && h.Gia != null)
                .OrderBy(h => h.Gia)
                .ToList();
            ViewBag.TieuDe = "Le Thi Dieu Linh";
            return View(ds);
        }

        public IActionResult HangHoaTheoLoai(int maLoai)
        {
            var ds = _db.HangHoas
                .Where(h => h.MaLoai == maLoai)
                .OrderBy(h => h.MaHang)
                .ToList();
            ViewBag.TieuDe = "New Products";
            return PartialView("LeThiDieuLinh_MainContent", ds);
        }
        [HttpGet]
        public IActionResult Create()
        {
            NapLoaiHang();
            return View(new HangHoaCreateVM());
        }

        [HttpPost]
        public IActionResult Create(HangHoaCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                NapLoaiHang(vm.MaLoai);
                return View(vm);
            }

            _db.HangHoas.Add(new HangHoa
            {
                MaLoai = vm.MaLoai,
                TenHang = vm.TenHang,
                Gia = vm.Gia,
                Anh = vm.Anh
            });
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private void NapLoaiHang(int? chon = null)
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiHangs.ToList(), "MaLoai", "TenLoai", chon);
        }
    }
}
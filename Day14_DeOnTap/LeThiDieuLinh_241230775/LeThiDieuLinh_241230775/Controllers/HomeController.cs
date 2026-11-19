using System.ComponentModel.DataAnnotations;
using LeThiDieuLinh_241230775.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeThiDieuLinh_241230775.Controllers;

public class HomeController : Controller
{
    private readonly QlnhaSachContext _db;
    public HomeController(QlnhaSachContext db) { _db = db; }

    // Câu 3: sách có Gia >= 100 (Gia NULL bị loại)
    public IActionResult Index()
    {
        var ds = _db.Saches
                    .Where(s => s.Gia != null && s.Gia >= 100)
                    .OrderBy(s => s.MaSach)
                    .ToList();
        ViewBag.TieuDe = "Le Thi Dieu Linh";
        return View(ds);
    }
    public IActionResult SachTheoLoai(int maTL)
    {
        var tl = _db.TheLoais.Find(maTL);
        if (tl == null) return NotFound();

        var ds = _db.Saches.Where(s => s.MaTl == maTL).OrderBy(s => s.MaSach).ToList();
        ViewBag.TieuDe = tl.TenTl;
        return PartialView("LeThiDieuLinh_MainContent", ds);
    }
    [HttpGet]
    public IActionResult Create()
    {
        NapTheLoai();
        return View(new SachCreateVM());
    }

    [HttpPost]
    public IActionResult Create(SachCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            NapTheLoai(vm.MaTL);
            return View(vm);
        }

        _db.Saches.Add(new Sach
        {
            MaTl = vm.MaTL!.Value,
            TenSach = vm.TenSach,
            Gia = vm.Gia,
            Anh = vm.Anh
        });
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private void NapTheLoai(int? chon = null)
    {
        ViewBag.DsTheLoai = new SelectList(_db.TheLoais.ToList(), "MaTl", "TenTl", chon);
    }
}

public class SachCreateVM
{
    [Required(ErrorMessage = "Vui lòng chọn thể loại")]
    public int? MaTL { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = string.Empty;

    [Required(ErrorMessage = "Giá không được để trống")]
    public decimal? Gia { get; set; }

    public string? Anh { get; set; }
}
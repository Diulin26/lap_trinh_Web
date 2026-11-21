using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LeThiDieuLinh_241230775.Models;

namespace LeThiDieuLinh_241230775.Controllers;

public class HomeController : Controller
{
    private readonly QLTaiSanContext _db;

    public HomeController(QLTaiSanContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var ds = _db.TaiSans
                    .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                    .OrderBy(t => t.MaTs)
                    .ToList();
        ViewBag.TieuDe = "Lê Thị Diệu Linh";
        return View(ds);
    }

    public IActionResult TaiSanTheoLoai(int maLoai)
    {
        var loai = _db.LoaiTaiSans.Find(maLoai);
        if (loai == null) return NotFound();

        var ds = _db.TaiSans
                    .Where(t => t.MaLoai == maLoai)
                    .OrderBy(t => t.MaTs)
                    .ToList();
        ViewBag.TieuDe = loai.TenLoai;                          
        return PartialView("LeThiDieuLinh_MainContent", ds);   
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var ts = _db.TaiSans.Find(id);
        if (ts == null) return NotFound();

        NapLoai(ts.MaLoai);
        return View(new TaiSanVM
        {
            MaTs = ts.MaTs,
            MaLoai = ts.MaLoai,
            TenTs = ts.TenTs,
            NguyenGia = ts.NguyenGia,
            Anh = ts.Anh
        });
    }

    [HttpPost]
    public IActionResult Edit(TaiSanVM vm)
    {
        if (!ModelState.IsValid)
        {
            NapLoai(vm.MaLoai);
            return View(vm);                
        }

        var ts = _db.TaiSans.Find(vm.MaTs);
        if (ts == null) return NotFound();

        ts.MaLoai = vm.MaLoai;               
        ts.TenTs = vm.TenTs;
        ts.NguyenGia = vm.NguyenGia;
        ts.Anh = vm.Anh;
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private void NapLoai(int? chon = null)
    {
        ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", chon);
    }
}

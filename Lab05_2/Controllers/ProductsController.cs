using Lab05_2.Models;
using Lab05_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab05_2.Controllers
{
    public class ProductsController : Controller
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private const long MaxImageSize = 2 * 1024 * 1024; // 2MB

        private readonly StoreData _store;
        private readonly IWebHostEnvironment _env;

        public ProductsController(StoreData store, IWebHostEnvironment env)
        {
            _store = store;
            _env = env;
        }

        // ---------- Danh sach ----------
        public IActionResult Index()
        {
            ViewBag.CategoryNames = _store.Categories.ToDictionary(c => c.Id, c => c.Name);
            return View(_store.GetAll());
        }

        // ---------- Xem chi tiet ----------
        public IActionResult Details(int id)
        {
            var product = _store.GetById(id);
            if (product == null) return NotFound();
            ViewBag.CategoryName = CategoryName(product.CategoryId);
            return View(product);
        }

        // ---------- Them moi ----------
        public IActionResult Create()
        {
            LoadCategories(null);
            return View(new Product());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ValidateCategory(product);
            ValidateImage(product.ImageFile, required: true);

            if (!ModelState.IsValid)
            {
                LoadCategories(product.CategoryId);
                return View(product);
            }

            product.Image = await SaveImageAsync(product.ImageFile!);
            _store.Add(product);
            TempData["Success"] = "Thêm sản phẩm thành công.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Chinh sua ----------
        public IActionResult Edit(int id)
        {
            var product = _store.GetById(id);
            if (product == null) return NotFound();
            LoadCategories(product.CategoryId);
            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var existing = _store.GetById(id);
            if (existing == null) return NotFound();

            product.Id = id;
            product.Image = existing.Image;

            ValidateCategory(product);
            ValidateImage(product.ImageFile, required: false);

            if (!ModelState.IsValid)
            {
                LoadCategories(product.CategoryId);
                return View(product);
            }

            if (product.ImageFile != null && product.ImageFile.Length > 0)
            {
                DeleteImage(existing.Image);
                product.Image = await SaveImageAsync(product.ImageFile);
            }

            _store.Update(product);
            TempData["Success"] = "Cập nhật sản phẩm thành công.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Xoa ----------
        public IActionResult Delete(int id)
        {
            var product = _store.GetById(id);
            if (product == null) return NotFound();
            ViewBag.CategoryName = CategoryName(product.CategoryId);
            return View(product);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _store.GetById(id);
            if (product == null) return NotFound();

            DeleteImage(product.Image);
            _store.Delete(id);
            TempData["Success"] = "Đã xóa sản phẩm.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Ham ho tro ----------
        private void LoadCategories(int? selectedId)
        {
            ViewBag.Categories = new SelectList(_store.Categories, "Id", "Name", selectedId);
        }

        private string CategoryName(int id) =>
            _store.Categories.FirstOrDefault(c => c.Id == id)?.Name ?? "(Không xác định)";

        // CategoryId phai nam trong danh sach Category
        private void ValidateCategory(Product product)
        {
            if (product.CategoryId > 0 && !_store.Categories.Any(c => c.Id == product.CategoryId))
            {
                ModelState.AddModelError(nameof(Product.CategoryId),
                    "Danh mục không hợp lệ, vui lòng chọn lại trong danh sách.");
            }
        }

        private void ValidateImage(IFormFile? file, bool required)
        {
            if (file == null || file.Length == 0)
            {
                if (required)
                    ModelState.AddModelError(nameof(Product.ImageFile), "Vui lòng chọn ảnh sản phẩm.");
                return;
            }

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext) || !file.ContentType.StartsWith("image/"))
            {
                ModelState.AddModelError(nameof(Product.ImageFile),
                    "Chỉ chấp nhận file ảnh có đuôi .jpg, .jpeg, .png, .gif hoặc .webp.");
            }
            else if (file.Length > MaxImageSize)
            {
                ModelState.AddModelError(nameof(Product.ImageFile), "Dung lượng ảnh tối đa là 2MB.");
            }
        }

        // Upload anh vao wwwroot/products
        private async Task<string> SaveImageAsync(IFormFile file)
        {
            var folder = Path.Combine(_env.WebRootPath, "products");
            Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName).ToLowerInvariant();
            var path = Path.Combine(folder, fileName);
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }

        private void DeleteImage(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            var path = Path.Combine(_env.WebRootPath, "products", Path.GetFileName(fileName));
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
        }
    }
}

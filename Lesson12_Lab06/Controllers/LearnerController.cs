using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

        // Biến toàn cục: số phần tử trên 1 trang
        private int pageSize = 3;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // Trang đầy đủ: hiển thị trang đầu tiên
        public IActionResult Index(int? mid)
        {
            IQueryable<Learner> learners = db.Learners;
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                ViewBag.mid = mid;
            }

            // tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // trả số trang về view để hiển thị nav-phân trang
            ViewBag.pageNum = pageNum;
            // lấy dữ liệu trang đầu
            var result = learners.OrderBy(l => l.LearnerID)
                                 .Take(pageSize)
                                 .Include(m => m.Major).ToList();
            return View(result);
        }

        // Action được AJAX gọi: phân trang kết hợp lọc và tìm kiếm
        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            // lấy toàn bộ learners chuyển về IQueryable để query
            IQueryable<Learner> learners = db.Learners;

            // lấy chỉ số trang, nếu null hoặc <= 0 thì gán mặc định bằng 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);

            // nếu có mid thì lọc theo chuyên ngành
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                // gửi mid về view để ghi lại trên nav-phân trang
                ViewBag.mid = mid;
            }

            // nếu có keyword thì tìm kiếm theo tên
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var kw = keyword.Trim().ToLower();
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(kw));
                // gửi keyword về view để ghi lại trên nav-phân trang
                ViewBag.keyword = keyword.Trim();
            }

            // tính số trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // gửi số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;

            // chọn dữ liệu trong trang hiện tại
            var result = learners.OrderBy(l => l.LearnerID)
                                 .Skip(pageSize * (page - 1))
                                 .Take(pageSize)
                                 .Include(m => m.Major).ToList();
            return PartialView("LearnerTable", result);
        }

        // ---------- CRUD ----------
        public IActionResult Create()
        {
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Learner learner)
        {
            ModelState.Remove(nameof(Learner.Major));
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        public IActionResult Edit(int id)
        {
            var learner = db.Learners.Find(id);
            if (learner == null) return NotFound();
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Learner learner)
        {
            if (id != learner.LearnerID) return NotFound();
            ModelState.Remove(nameof(Learner.Major));
            if (ModelState.IsValid)
            {
                db.Update(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        public IActionResult Delete(int id)
        {
            var learner = db.Learners.Include(l => l.Major).FirstOrDefault(l => l.LearnerID == id);
            if (learner == null) return NotFound();
            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

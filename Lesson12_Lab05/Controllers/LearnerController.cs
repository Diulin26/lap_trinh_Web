using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    //author: Le Thi Dieu Linh
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // ---------- 1. Lọc dữ liệu ĐỒNG BỘ ----------
        public IActionResult Index(int? mid)
        {
            if (mid == null)
            {
                var learners = db.Learners
                    .Include(m => m.Major).ToList();
                return View(learners);
            }
            else
            {
                var learners = db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major).ToList();
                return View(learners);
            }
        }

        // ---------- 2. Lọc dữ liệu KHÔNG ĐỒNG BỘ (AJAX) ----------
        // Trang đầy đủ (hiển thị tất cả learner, lọc bằng AJAX)
        public IActionResult IndexAjax()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }

        // Action được AJAX gọi: trả về PartialView chỉ chứa bảng dữ liệu
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners
                .Where(l => l.MajorID == mid)
                .Include(m => m.Major).ToList();
            return PartialView("LearnerTable", learners);
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

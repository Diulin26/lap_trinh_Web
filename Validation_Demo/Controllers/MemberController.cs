using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Validation_Demo.Models;

namespace Validation_Demo.Controllers 
{
    public class MemberController :Controller
    {
        private static List<Member> members = new List<Member>();
        // GET: MemberController1
       
        public ActionResult Index()
        {
            return View (members);
        }

        // GET: MemberController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if(!ModelState.IsValid) {
                    return View();
                }
                members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

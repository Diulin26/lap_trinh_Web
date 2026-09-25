using LTDLLesson06Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTBLesson06Models.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Ltdl_User> Users = new List<Ltdl_User>
        {
            new Ltdl_User
            {
                LtdlId = 1,
                LtdlName = "Nguyễn Văn A",
                LtdlAddress = "Khu 1",
                LtdlEmail = "nguyenvana@gmail.com"
            },
            new Ltdl_User
            {
                LtdlId = 2,
                LtdlName = "Trần Thị B",
                LtdlAddress = "Khu 2",
                LtdlEmail = "tranthib@gmail.com"
            },
            new Ltdl_User
            {
                LtdlId = 3,
                LtdlName = "Lê Văn C",
                LtdlAddress = "Khu 3",
                LtdlEmail = "levanc@gmail.com"
            }
        };

        public IActionResult Index()
        {
            return View("Ltdl_Index", Users);
        }

        public IActionResult Create()
        {
            return View("Ltdl_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ltdl_User user)
        {
            if (!ModelState.IsValid)
                return View("Ltdl_Create", user);

            user.LtdlId = Users.Count == 0 ? 1 : Users.Max(x => x.LtdlId) + 1;
            Users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long id)
        {
            var user = Users.FirstOrDefault(x => x.LtdlId == id);
            if (user == null)
                return NotFound();

            return View("Ltdl_Details", user);
        }

        public IActionResult Edit(long id)
        {
            var user = Users.FirstOrDefault(x => x.LtdlId == id);
            if (user == null)
                return NotFound();

            return View("Ltdl_Edit", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ltdl_User user)
        {
            if (!ModelState.IsValid)
                return View("Ltdl_Edit", user);

            var oldUser = Users.FirstOrDefault(x => x.LtdlId == user.LtdlId);
            if (oldUser == null)
                return NotFound();

            oldUser.LtdlName = user.LtdlName;
            oldUser.LtdlAddress = user.LtdlAddress;
            oldUser.LtdlEmail = user.LtdlEmail;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            var user = Users.FirstOrDefault(x => x.LtdlId == id);
            if (user == null)
                return NotFound();

            return View("Ltdl_Delete", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var user = Users.FirstOrDefault(x => x.LtdlId == id);
            if (user != null)
                Users.Remove(user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("Ltdl_Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Ltdl_Login login)
        {
            if (login.LtdlUserName == "Peter" && login.LtdlPassword == "pass@123")
            {
                return Content("Welcome " + login.LtdlUserName);
            }

            ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View("Ltdl_Login", login);
        }
    }
}

using LTDLLesson06Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTDLLesson06Models.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<LtdlMember> Members = new List<LtdlMember>
        {
            new LtdlMember
            {
                LtdlMemberId = Guid.NewGuid(),
                LtdlMemberUserName = "linh",
                LtdlMemberPassword = "Linhehe",
                LtdlMemberEmail = "lelinh@gmail.com",
                LtdlMemberFullName = "Le Thi Dieu Linh"
            },
            new LtdlMember
            {
                LtdlMemberId = Guid.NewGuid(),
                LtdlMemberUserName = "aaaaaaaa",
                LtdlMemberPassword = "123456",
                LtdlMemberEmail = "aaaaaaa@gmail.com",
                LtdlMemberFullName = "Trần Thị A"
            },
            new LtdlMember
            {
                LtdlMemberId = Guid.NewGuid(),
                LtdlMemberUserName = "bbbbbbb",
                LtdlMemberPassword = "123456",
                LtdlMemberEmail = "bbbbbb@gmail.com",
                LtdlMemberFullName = "Trần Thị B"
            },
            new LtdlMember
            {
                LtdlMemberId = Guid.NewGuid(),
                LtdlMemberUserName = "deedeee",
                LtdlMemberPassword = "123456",
                LtdlMemberEmail = "phamthid@gmail.com",
                LtdlMemberFullName = "Trần Thị D"
            },
            new LtdlMember
            {
                LtdlMemberId = Guid.NewGuid(),
                LtdlMemberUserName = "hehehe",
                LtdlMemberPassword = "123456",
                LtdlMemberEmail = "eeeee@gmail.com",
                LtdlMemberFullName = "Trần Thị E"
            }
        };

        public static List<LtdlMember> Members1 => Members;

        public IActionResult Index()
        {
            return View(Members1);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LtdlMember member)
        {
            member.LtdlMemberId = Guid.NewGuid();
            Members1.Add(member);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.LtdlMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        public IActionResult Edit(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.LtdlMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(LtdlMember member)
        {
            var oldMember = Members1.FirstOrDefault(x => x.LtdlMemberId == member.LtdlMemberId);
            if (oldMember == null) return NotFound();

            oldMember.LtdlMemberUserName = member.LtdlMemberUserName;
            oldMember.LtdlMemberPassword = member.LtdlMemberPassword;
            oldMember.LtdlMemberEmail = member.LtdlMemberEmail;
            oldMember.LtdlMemberFullName = member.LtdlMemberFullName;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.LtdlMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.LtdlMemberId == id);
            if (member != null)
                Members1.Remove(member);

            return RedirectToAction(nameof(Index));
        }
    }
}
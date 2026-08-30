using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using System.Linq;

namespace MyAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/04.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                }
            };

            ViewBag.Accounts = accounts;

            return View();
        }


        // Truyền tham số id vào Action Profile
        [Route("ho-so-cua-toi/{id}", Name = "profile")]
        public IActionResult Profile(int id)
        {
            // Danh sách Account giống như trong Action Index
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1,
                    Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },

                new Account()
                {
                    Id = 2,
                    Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },

                new Account()
                {
                    Id = 3,
                    Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/04.png"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                }
            };

            // Tìm Account theo Id được truyền vào
            Account account = accounts.FirstOrDefault(ac => ac.Id == id);

            // Gửi đối tượng account qua View
            ViewBag.account = account;

            return View();
        }
    }
}
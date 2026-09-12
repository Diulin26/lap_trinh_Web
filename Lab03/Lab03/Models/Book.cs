using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Lab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }

        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "Phi Công",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/pic1.jpg",
                    Price = 500000,
                    TotalPage = 180,
                    Sumary = ""
                },
                new Book()
                {
                    Id = 2,
                    Title = "Tiệm giặt là nửa đêm ",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/pic2.jpg",
                    Price = 600000,
                    TotalPage = 200,
                    Sumary = ""
                },
                new Book()
                {
                    Id = 3,
                    Title = "Cú rời đất xanh",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/pic3.jpg",
                    Price = 700000,
                    TotalPage = 150,
                    Sumary = ""
                },
                new     Book()
                {
                    Id = 4,
                    Title = "Câu chuyện nghệ thuật đương đại",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/pic4.jpg",
                    Price = 800000,
                    TotalPage = 250,
                    Sumary = ""
                }
            };
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Evgendy Lovodazkin" },
            new SelectListItem { Value = "2", Text = "Park Ji-Young" },
            new SelectListItem { Value = "3", Text = "Vĩ Ngư" },
            new SelectListItem { Value = "4", Text = "Tony Godfrey" }
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Tieu thuyet" },
            new SelectListItem { Value = "2", Text = "Tam su" },
            new SelectListItem { Value = "3", Text = "Van hoc" },
            new SelectListItem { Value = "4", Text = "Trinh tham" }
        };


    }
}
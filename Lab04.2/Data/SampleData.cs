using DemoLab.Models;

namespace DemoLab.Data
{
    // Du lieu mau (thay cho CSDL)
    public static class SampleData
    {
        public static List<Category> GetCategories() => new()
        {
            new Category { Id = 1,  Name = "Áo dài" },
            new Category { Id = 2,  Name = "Áo đông" },
            new Category { Id = 3,  Name = "Túi xách" },
            new Category { Id = 4,  Name = "Đồng hồ" },
            new Category { Id = 5,  Name = "Ví da" },
            new Category { Id = 6,  Name = "Thắt lưng da" },
            new Category { Id = 7,  Name = "Tủ lạnh" },
            new Category { Id = 8,  Name = "Tivi" },
            new Category { Id = 9,  Name = "Quạt điện" },
            new Category { Id = 10, Name = "Lò sưởi" }
        };

        private static List<Product> Products() => Enumerable.Range(1, 6).Select(i => new Product
        {
            Id = i,
            Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
            Image = "noi-com.svg",
            Price = 2850000
        }).ToList();

        // San pham moi nhat (hien thi tu Action Index cua HomeController)
        public static List<Product> GetNewProducts(int take = 3) => Products().Take(take).ToList();

        // San pham hot (hien thi tu ViewComponent HotProduct)
        public static List<Product> GetHotProducts(int take = 3) => Products().Skip(3).Take(take).ToList();
    }
}

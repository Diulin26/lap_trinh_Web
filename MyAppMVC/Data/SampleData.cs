using MyAppMVC.Models;

namespace MyAppMVC.Data
{
    // Du lieu mau (thay cho CSDL)
    public static class SampleData
    {
        private const string Lorem = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa eligendi, voluptatem perspiciatis qui delectus ab unde iure doloribus natus expedita, laborum blanditiis quaerat repellendus necessitatibus nam quo earum ex suscipit.";

        public static List<Category> GetCategories() => new()
        {
            new Category { Id = 1, Name = "Quần Áo" },
            new Category { Id = 2, Name = "Túi xách" },
            new Category { Id = 3, Name = "Đồng hồ" },
            new Category { Id = 4, Name = "Ti vi" },
            new Category { Id = 5, Name = "Tủ lạnh" },
            new Category { Id = 6, Name = "Máy bơm" },
            new Category { Id = 7, Name = "Quạt điện" },
            new Category { Id = 8, Name = "Lò sưởi" }
        };

        public static List<Product> GetProducts() => new()
        {
            new Product { Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", Image = "p1.svg", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = Lorem, Status = true,  CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", Image = "p2.svg", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = Lorem, Status = true,  CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", Image = "p3.svg", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = Lorem, Status = true,  CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", Image = "p4.svg", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = Lorem, Status = false, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 5, Name = "Túi thời trang mẫu mới 2021", Image = "p5.svg", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = Lorem, Status = true,  CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 6, Name = "Túi thời trang da cá sấu", Image = "p6.svg", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = Lorem, Status = true,  CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) }
        };
    }
}

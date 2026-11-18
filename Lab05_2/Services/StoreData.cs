using Lab05_2.Models;

namespace Lab05_2.Services
{
    // Luu tru trong bo nho: danh sach Category va Product (thay cho CSDL)
    public class StoreData
    {
        private readonly object _lock = new();
        private readonly List<Product> _products = new();
        private int _nextId = 1;

        public List<Category> Categories { get; } = new()
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" },
            new Category { Id = 4, Name = "Gia dụng" }
        };

        public StoreData()
        {
            Add(new Product { Name = "Điện thoại thông minh X1", Image = "seed1.svg", Price = 5000000, SalePrice = 4200000, CategoryId = 1, Description = "Điện thoại màn hình lớn, pin bền, camera sắc nét." });
            Add(new Product { Name = "Laptop văn phòng Pro 14", Image = "seed2.svg", Price = 15000000, SalePrice = 13000000, CategoryId = 2, Description = "Laptop mỏng nhẹ, phù hợp học tập và làm việc." });
            Add(new Product { Name = "Tai nghe không dây Air", Image = "seed3.svg", Price = 1200000, SalePrice = 990000, CategoryId = 3, Description = "Tai nghe Bluetooth chống ồn, pin dùng 20 giờ." });
        }

        public List<Product> GetAll()
        {
            lock (_lock) return _products.Select(p => p.Clone()).OrderBy(p => p.Id).ToList();
        }

        public Product? GetById(int id)
        {
            lock (_lock) return _products.FirstOrDefault(p => p.Id == id)?.Clone();
        }

        public void Add(Product product)
        {
            lock (_lock)
            {
                var copy = product.Clone();
                copy.Id = _nextId++;
                _products.Add(copy);
                product.Id = copy.Id;
            }
        }

        public bool Update(Product product)
        {
            lock (_lock)
            {
                var index = _products.FindIndex(p => p.Id == product.Id);
                if (index < 0) return false;
                _products[index] = product.Clone();
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock) return _products.RemoveAll(p => p.Id == id) > 0;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Lab05_2.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab05_2.Models
{
    public class Product
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải có từ 6 đến 150 ký tự.")]
        public string Name { get; set; } = string.Empty;

        // Ten file anh da upload trong wwwroot/products (do controller gan, khong bind tu form)
        [BindNever]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        // File anh nguoi dung chon (bat buoc khi them moi, kiem tra trong controller)
        [Display(Name = "Hình ảnh")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm.")]
        [Range(100000, 1000000000000, ErrorMessage = "Giá sản phẩm phải từ 100.000 trở lên.")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi.")]
        [SalePriceLimit]
        public float SalePrice { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục.")]
        public int CategoryId { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm.")]
        [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự.")]
        [NoBadWords]
        public string Description { get; set; } = string.Empty;

        public Product Clone()
        {
            var copy = (Product)MemberwiseClone();
            copy.ImageFile = null;
            return copy;
        }
    }
}

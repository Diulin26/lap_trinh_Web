using System.ComponentModel.DataAnnotations;

namespace LeThiDieuLinh_241230775.Models
{
    public class SachCreateVM
    {
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Tên sách không được để trống")]
        public int? MaTl { get; set;}
   
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Tên sách không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sách tối đa 100 ký tự")]
        public string TenSach { get; set; } = null!;

        [Display(Name = "Giá (nghìn đồng)")]
        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(50, 1000, ErrorMessage = "Giá phải nằm trong khoảng từ 50 đến 1000")]
        public decimal? Gia { get; set; }

    
        [Display(Name = "Tên file ảnh")]
        [FileExtensions(Extensions = "jpg,jpeg,png,webp",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
        public string? Anh { get; set; }


    }
}

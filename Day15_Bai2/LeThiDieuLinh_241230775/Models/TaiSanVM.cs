using System.ComponentModel.DataAnnotations;

namespace LeThiDieuLinh_241230775.Models;

public class TaiSanVM
{
    public int MaTs { get; set; }

    [Display(Name = "MaLoai")]
    public int MaLoai { get; set; }

    [Display(Name = "TenTS")]
    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    [StringLength(100, ErrorMessage = "Tên tài sản tối đa 100 ký tự")]
    public string TenTs { get; set; } = null!;

    [Display(Name = "NguyenGia")]
    [Required(ErrorMessage = "Vui lòng nhập nguyên giá")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải nằm trong khoảng từ 1 đến 2000 (triệu đồng)")]
    public decimal? NguyenGia { get; set; }

    [Display(Name = "Anh")]
    [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
    [FileExtensions(Extensions = "jpg,jpeg,png,webp",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }
}

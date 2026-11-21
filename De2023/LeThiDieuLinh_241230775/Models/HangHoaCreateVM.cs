using System.ComponentModel.DataAnnotations;

namespace LeThiDieuLinh_241230775.Models;

public class HangHoaCreateVM
{
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên hàng không được để trống")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
    public decimal? Gia { get; set; }

    [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
    [FileExtensions(Extensions = "jpg,png,gif,tiff",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
    public string? Anh { get; set; }
}
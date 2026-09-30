using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Validation_Demo.Models
{

    
    public class Member
    {
        public int Id { get; set; }

        [DisplayName("Taì khoản")]
        [Required(ErrorMessage = "Tai khoan khong duoc de trong")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tai kkhoan co do dai 3-20 ki tu")]
        public string UserName { get; set; }

        [DisplayName("Mat khau")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mat khau toi thieu 8 ki tu")]
        public string password { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email khong duoc de trong")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DisplayName("Dien thoai")]
        [Required(ErrorMessage = "Ban chua nhap so dien thoai")]
        [RegularExpression(@"^0\d{9}",ErrorMessage ="Dien thoai phai la 10 ki tu, bat dau bang so 0")]
        public string phone { get; set; }


    }
}

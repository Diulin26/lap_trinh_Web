using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Lab05_2.Models;

namespace Lab05_2.Validation
{
    // Gia khuyen mai: khong am va phai thap hon gia chuan it nhat 10% (<= 90% gia chuan)
    public class SalePriceLimitAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not float sale) return ValidationResult.Success;

            if (sale < 0)
                return new ValidationResult("Giá khuyến mãi không được là số âm.");

            if (validationContext.ObjectInstance is Product p && p.Price > 0)
            {
                var max = p.Price * 0.9f;
                if (sale > max)
                {
                    return new ValidationResult(
                        $"Giá khuyến mãi phải thấp hơn giá chuẩn ít nhất 10% (tối đa {max.ToString("N0", CultureInfo.InvariantCulture)}).");
                }
            }
            return ValidationResult.Success;
        }
    }
}

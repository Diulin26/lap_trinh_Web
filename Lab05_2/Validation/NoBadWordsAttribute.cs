using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab05_2.Validation
{
    // Khong cho phep chua cac tu nhay cam
    public class NoBadWordsAttribute : ValidationAttribute
    {
        private static readonly string[] BadWords =
            { "die", "admin", "fack", "fuck", "shit", "địt", "đụ" };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var text = value as string;
            if (string.IsNullOrWhiteSpace(text)) return ValidationResult.Success;

            var found = BadWords
                .Where(w => Regex.IsMatch(text,
                    $@"(?<![\p{{L}}\p{{N}}]){Regex.Escape(w)}(?![\p{{L}}\p{{N}}])",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                .ToList();

            if (found.Count > 0)
            {
                return new ValidationResult(
                    $"Mô tả chứa từ nhạy cảm không được phép: {string.Join(", ", found)}. Vui lòng chỉnh sửa lại.");
            }
            return ValidationResult.Success;
        }
    }
}

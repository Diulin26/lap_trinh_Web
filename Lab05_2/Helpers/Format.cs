using System.Globalization;

namespace Lab05_2.Helpers
{
    public static class Format
    {
        // 5000000 -> "5.000.000 đ"
        public static string Money(float value) =>
            value.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + " đ";
    }
}

using System.Globalization;

namespace QLLT.Utils
{
    public static class FormatHelper
    {
        static readonly CultureInfo vi = new CultureInfo("vi-VN");

        public static string Money(this decimal value, string suffix = " đ")
            => string.Format(vi, "{0:#,0}", value) + suffix;

        public static string MoneyNoSuffix(this decimal value)
            => string.Format(vi, "{0:#,0}", value);
    }
}

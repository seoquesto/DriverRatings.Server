namespace src.DriverRatings.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string text) => string.IsNullOrEmpty(text);
    }
}
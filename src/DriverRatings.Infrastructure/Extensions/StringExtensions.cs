using System.Text.RegularExpressions;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public static class StringExtensions
  {
    private static readonly Regex EmailRegex = new Regex(
      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
      RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static bool IsEmpty(this string text) => string.IsNullOrEmpty(text);

    public static bool IsValidEmail(string email)
    {
      if (string.IsNullOrEmpty(email))
      {
        return false;
      }

      return EmailRegex.IsMatch(email);
    }
  }
}
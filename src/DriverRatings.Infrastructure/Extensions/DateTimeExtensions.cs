using System;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public static class DateTimeExtensions
  {
    public static long ToTimestamp(this DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
  }
}
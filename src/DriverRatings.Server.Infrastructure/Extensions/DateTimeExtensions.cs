using System;

namespace src.DriverRatings.Server.Infrastructure.Extensions
{
  public static class DateTimeExtensions
  {
    public static long ToTimestamp(this DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
  }
}
using System;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public static class CacheExtensions
  {
    public static void SetJwt(this IMemoryCache memoryCache, Guid tokenId, JwtDto jwtDto)
    {
      memoryCache.Set<JwtDto>(GetJwtKey(tokenId), jwtDto, TimeSpan.FromSeconds(5));
    }

    public static JwtDto GetJwt(this IMemoryCache memoryCache, Guid tokenId)
    {
      return memoryCache.Get<JwtDto>(GetJwtKey(tokenId));
    }

    public static string GetJwtKey(Guid tokenId)
    {
      return $"jwt-{tokenId}";
    }
  }
}
using System;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public static class CacheExtensions
  {
    public static void SetJwt(this IMemoryCache memoryCache, Guid cacheId, JwtDto jwtDto)
    {
      memoryCache.Set<JwtDto>(GetJwtKey(cacheId), jwtDto, TimeSpan.FromSeconds(5));
    }

    public static JwtDto GetJwt(this IMemoryCache memoryCache, Guid cacheId)
    {
      return memoryCache.Get<JwtDto>(GetJwtKey(cacheId));
    }

    public static string GetJwtKey(Guid cacheId)
    {
      return $"jwt-{cacheId}";
    }
  }
}
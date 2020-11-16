using AutoMapper;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configuration() {
          return new MapperConfiguration(config => {
            config.CreateMap<User, UserDto>();
            config.CreateMap<Post, PostDto>();
            config.CreateMap<Comment, CommentDto>();
            config.CreateMap<UserInfo, UserInfoDto>();
          }).CreateMapper();
        }
    }
}
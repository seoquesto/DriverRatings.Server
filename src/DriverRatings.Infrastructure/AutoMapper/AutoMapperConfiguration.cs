using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.AutoMapper
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
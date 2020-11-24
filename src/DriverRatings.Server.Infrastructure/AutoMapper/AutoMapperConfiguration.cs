using AutoMapper;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.AutoMapper
{
  public static class AutoMapperConfiguration
  {
    public static IMapper Configuration()
    {
      return new MapperConfiguration(config =>
      {
        config.CreateMap<User, UserDto>();
        config.CreateMap<Post, PostDto>();
        config.CreateMap<Plate, PlateDto>();
        config.CreateMap<PlateIdentifier, PlateIdentifierDto>();
        config.CreateMap<PlateDetails, PlateDetailsDto>();
        config.CreateMap<CommentBase, CommentBaseDto>();
        config.CreateMap<PostComment, PostCommentDto>();
        config.CreateMap<PlateComment, PlateCommentDto>();
        config.CreateMap<CreatorInfo, CreatorInfoDto>();
      }).CreateMapper();
    }
  }
}
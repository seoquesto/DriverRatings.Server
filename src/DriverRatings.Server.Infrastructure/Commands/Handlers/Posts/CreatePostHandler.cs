using System;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.Commands.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Posts
{
  public class CreatePostHandler : ICommandHandler<CreatePost, Guid>
  {
    private readonly IPostsService _postsService;
    private readonly IPlatesDetailsService _platesDetailsService;

    public CreatePostHandler(IPostsService postsService, IPlatesDetailsService platesDetailsService)
      => (_postsService, _platesDetailsService) = (postsService, platesDetailsService);

    public async Task<Guid> HandleAsync(CreatePost command)
    {
      await this._platesDetailsService.AddPlateAsync(command.PlateIdentifier, command.PlateNumber);
      var postId = await this._postsService.AddPostAsync(command.UserId, command.Content, command.PlateIdentifier, command.PlateNumber);
      return postId;
    }
  }
}
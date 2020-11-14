using System;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Exceptions;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Services
{
  public class PostsService : IPostsService
  {
    private readonly IPostsRepository _postsRepository;
    private readonly IUsersService _usersService;
    private readonly IMapper mapper;

    public PostsService(IPostsRepository postsRepository, IUsersService usersService, IMapper mapper)
    {
      this._usersService = usersService;
      this._postsRepository = postsRepository;
      this.mapper = mapper;
    }

    public async Task<Guid> AddPostAsync(Guid userId, string content)
    {
      var user = await this._usersService.GetByIdAsync(userId);
      if (user is null)
      {
        throw new UserNotFoundException($@"User with id: ""{userId}"" was not found.");
      }

      var post = new Post(new UserInfo(user.UserId, user.Username, user.Email), content);
      await this._postsRepository.AddAsync(post);

      return post.PostId;
    }

    public async Task DeletePostAsync(Guid postId)
    {
      var post = await this._postsRepository.GetByPostIdAsync(postId);
      if (post is null)
      {
        throw new PostNotFoundException(postId);
      }

      await this._postsRepository.DeleteAsync(post);
    }

    public async Task<PostDto> GetByPostIdAsync(Guid postId)
    {
      var post = await this._postsRepository.GetByPostIdAsync(postId);

      return this.mapper.Map<PostDto>(post);
    }
  }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Exceptions;

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

    public async Task AddPostAsync(Guid userId, string content)
    {
      var user = await this._usersService.GetByIdAsync(userId);
      if (user == null)
      {
        throw new ServiceException(UsersServiceErrorCodes.UserDoesNotExist, $@"User with id: ""{userId}"" does not exist!.");
      }

      var post = new Post(new UserInfo(userId, user.Username, user.Email), content);
      await this._postsRepository.AddAsync(post);
    }

    public async Task<PostDto> GetByPostId(Guid postId)
    {
      var post = await this._postsRepository.GetByPostId(postId);

      return this.mapper.Map<PostDto>(post);
    }
  }
}
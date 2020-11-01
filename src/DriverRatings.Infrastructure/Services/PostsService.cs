using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Repositories;

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
      if (string.IsNullOrEmpty(content))
      {
        throw new Exception("Post content cannot be empty!.");
      }

      var user = await this._usersService.GetByIdAsync(userId);
      if (user == null)
      {
        throw new Exception($@"User with id: ""{userId}"" does not exist!.");
      }

      var post = new Post(new UserInfo(userId, user.Username, user.Email), content);
      await this._postsRepository.AddAsync(post);
    }

    public async Task<PostDto> GetByPostId(Guid id)
    {
      var post = await this._postsRepository.GetByPostId(id);

      if (post == null)
      {
        throw new Exception($@"Post with id: ""{id}"" does not exist!.");
      }

      return this.mapper.Map<Post, PostDto>(post);
    }
  }
}
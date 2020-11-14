using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Exceptions;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Exceptions;
using src.DriverRatings.Infrastructure.Extensions;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Services
{
  public class PostsService : IPostsService
  {
    private readonly IPostsRepository _postsRepository;
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public PostsService(IPostsRepository postsRepository, IUsersService usersService, IMapper mapper)
    {
      this._usersService = usersService;
      this._postsRepository = postsRepository;
      this._mapper = mapper;
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

    public async Task DeletePostAsync(Guid userId, Guid postId)
    {
      var post = await this._postsRepository.GetByPostIdAsync(postId);
      if (post is null)
      {
        throw new PostNotFoundException(postId);
      }

      if (post.UserInfo.UserId != userId)
      {
        throw new UserNotAllowedToDoThatException(userId);
      }

      await this._postsRepository.DeleteAsync(post);
    }

    public async Task<PostDto> GetByPostIdAsync(Guid postId)
    {
      var post = await this._postsRepository.GetByPostIdAsync(postId);

      return this._mapper.Map<PostDto>(post);
    }

    public async Task AddCommentAsync(Guid userId, Guid postId, Guid commentId, string content)
    {
      var post = await this._postsRepository.GetByPostIdAsync(postId);
      if (post is null)
      {
        throw new PostNotFoundException(postId);
      }

      var user = await this._usersService.GetByIdAsync(userId);
      if (user is null)
      {
        throw new UserNotFoundException($@"User with id: ""{userId}"" was not found.");
      }

      var userInfo = new UserInfo(user.UserId, user.Username, user.Email);

      post.AddComment(new Comment(commentId, userInfo, content));

      await this._postsRepository.UpdateAsync(post);
    }

    public async Task<CommentDto> GetCommentAsync(Guid postId, Guid commentId)
    {
      if (postId == Guid.Empty)
      {
        throw new InvalidIdException("Invalid post id.");
      }
      if (commentId == Guid.Empty)
      {
        throw new InvalidIdException("Invalid comment id.");
      }

      var post = await this._postsRepository.GetByPostIdAsync(postId);
      var comment = post.Comments.FirstOrDefault(x => x.CommentId == commentId);

      return this._mapper.Map<CommentDto>(comment);
    }
  }
}
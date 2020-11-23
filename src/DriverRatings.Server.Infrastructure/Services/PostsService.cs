using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using src.DriverRatings.Server.Core.Exceptions;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Exceptions;
using src.DriverRatings.Server.Infrastructure.Extensions;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class PostsService : IPostsService
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IPostsRepository _postsRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public PostsService(IPostsRepository postsRepository, IUsersRepository usersRepository, IMapper mapper)
    {
      this._usersRepository = usersRepository;
      this._postsRepository = postsRepository;
      this._mapper = mapper;
    }

    public async Task<Guid> AddPostAsync(Guid userId, string content)
    {
      var user = await this._usersRepository.GetAsync(x => x.UserId == userId);
      if (user is null)
      {
        _logger.Error($@"User with id: ""{userId}"" was not found.");
        throw new UserNotFoundException($@"User with id: ""{userId}"" was not found.");
      }

      var creatorInfo = new CreatorInfo(user.UserId, user.Username);
      var post = new Post(creatorInfo, content);
      await this._postsRepository.AddAsync(post);

      _logger.Info($"Post with id: {post.PostId} has been added successfully.");
      return post.PostId;
    }

    public async Task AddCommentAsync(Guid userId, Guid postId, Guid commentId, string content)
    {
      var post = await this._postsRepository.GetAsync(x => x.PostId == postId);
      if (post is null)
      {
        _logger.Error($"Post not found: {postId.ToString()}.");
        throw new PostNotFoundException(postId);
      }

      var user = await this._usersRepository.GetAsync(x => x.UserId == userId);
      if (user is null)
      {
        _logger.Error($@"User with id: ""{userId}"" was not found.");
        throw new UserNotFoundException($@"User with id: ""{userId}"" was not found.");
      }

      var userInfo = new UserInfo(user.UserId, user.Username);

      post.AddComment(new Comment(commentId, userInfo, content));

      _logger.Info($"Comment with id: {commentId.ToString()} has been added successfully.");
      await this._postsRepository.UpdateAsync(post, x => x.PostId == postId);
    }

    public async Task<PostDto> GetByPostIdAsync(Guid postId)
    {
      var post = await this._postsRepository.GetAsync(x => x.PostId == postId);
      return this._mapper.Map<PostDto>(post);
    }

    public async Task<IEnumerable<PostDto>> GetPostsAssignedToUser(string username)
    {
      var modifiedUsername = username?.Trim().ToLowerInvariant();
      if (string.IsNullOrWhiteSpace(modifiedUsername))
      {
        throw new UserNotFoundException($"User with name: {modifiedUsername} was not found.");
      }

      var user = await this._usersRepository.GetAsync(x => x.Username == modifiedUsername);
      if (user is null)
      {
        throw new UserNotFoundException($@"User with name: ""{modifiedUsername}"" was not found.");
      }

      var posts = await this._postsRepository.FindAsync(x => x.UserInfo.UserId == user.UserId);
      return this._mapper.Map<IEnumerable<PostDto>>(posts);
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

      var post = await this._postsRepository.GetAsync(x => x.PostId == postId);
      var comment = post.Comments.FirstOrDefault(x => x.CommentId == commentId);

      return this._mapper.Map<CommentDto>(comment);
    }

    public async Task DeletePostAsync(Guid userId, Guid postId)
    {
      var post = await this._postsRepository.GetAsync(x => x.PostId == postId);
      if (post is null)
      {

        _logger.Error($"Post not found: {postId.ToString()}.");
        throw new PostNotFoundException(postId);
      }

      if (post.UserInfo.UserId != userId)
      {
        _logger.Error($"Post with id {postId} cannot be deleted because user with id: {userId} is not the post's author.");
        throw new UserNotAllowedToDoThatException(userId);
      }

      await this._postsRepository.DeleteAsync(x => x.PostId == postId);
      _logger.Info($"Post with id: {postId.ToString()} has been deleted successfully.");
    }
  }
}
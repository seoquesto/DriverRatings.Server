using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IPostsService : IService
  {
    Task<Guid> AddPostAsync(Guid userId, string content, string plateIdentifier, string plateNumber);
    Task AddCommentAsync(Guid userId, Guid postId, Guid commentId, string content);
    Task<PostDto> GetByPostIdAsync(Guid postId);
    Task<PostCommentDto> GetCommentAsync(Guid postId, Guid commentId);
    Task<IEnumerable<PostDto>> GetPostsAssignedToUser(string username);
    Task<IEnumerable<PostDto>> GetAllPostsAsync();
    Task<IEnumerable<PostDto>> GetAllPostsAsync(string plateIdentifier, string plateNumber);
    Task DeletePostAsync(Guid userId, Guid postId);
  }
}
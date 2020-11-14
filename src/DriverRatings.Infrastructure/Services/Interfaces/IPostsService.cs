using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IPostsService : IService
  {
    Task<Guid> AddPostAsync(Guid userId, string content);
    Task<PostDto> GetByPostIdAsync(Guid postId);
    Task DeletePostAsync(Guid postId);
    Task AddCommentAsync(Guid userId, Guid postId, Guid commentId, string content);
    Task<CommentDto> GetCommentAsync(Guid postId, Guid commentId);
  }
}
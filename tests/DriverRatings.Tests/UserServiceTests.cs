using System;
using Xunit;
using Moq;
using src.DriverRatings.Infrastructure.Repositories;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Infrastructure.Services;
using src.DriverRatings.Core.Models;

namespace DriverRatings.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Register_Async_Should_Invoke_Add_Async_On_Repository() {
          var userRepository = new Mock<IUserRepository>();
          var mapper = new Mock<IMapper>();

          var userService = new UserService(userRepository.Object, mapper.Object);
          await userService.RegisterAsync("username", "email@email.com", "password");
          userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

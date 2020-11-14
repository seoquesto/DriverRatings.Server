using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Infrastructure.Services;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace DriverRatings.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Register_Async_Should_Invoke_Add_Async_On_Repository() 
        {
          var userRepository = new Mock<IUsersRepository>();
          var mapper = new Mock<IMapper>();
          IEncrypter encrypter = new Encrypter();

          var userService = new UsersService(userRepository.Object, mapper.Object, encrypter);
          await userService.RegisterAsync(Guid.NewGuid(), "username", "email@email.com", "password", "user");
          userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

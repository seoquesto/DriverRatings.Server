using System;
using Xunit;
using Moq;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Infrastructure.Services;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace DriverRatings.Server.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Register_Async_Should_Invoke_Add_Async_On_Repository() 
        {
          var userRepository = new Mock<IUsersRepository>();
          var mapper = new Mock<IMapper>();
          IEncrypter encrypter = new Encrypter();

          var identityService = new IdentityService(userRepository.Object, encrypter);
          await identityService.RegisterAsync(Guid.NewGuid(), "username", "email@email.com", "password", "user");
          userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}

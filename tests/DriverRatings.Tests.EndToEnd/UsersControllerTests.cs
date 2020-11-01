using System.Threading.Tasks;
using DriverRatings.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using src.DriverRatings.Infrastructure.Commands.Users;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Net;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Tests.EndToEnd
{
  public class UsersControllerTests : IClassFixture<WebApplicationFactory<Startup>>
  {
    private readonly WebApplicationFactory<Startup> _factory;

    public UsersControllerTests(WebApplicationFactory<Startup> factory)
    {
      _factory = factory;
    }

    [Fact]
    public async Task User_Should_Be_Created_When_Valid_Paramaters()
    {
      var createUserCommand = new CreateUser
      {
        Username = "username",
        Email = "testemail@email.com",
        Password = "password",
      };

      var client = _factory.CreateClient();
      var response = await client.PostAsync("/users", GetPayload(createUserCommand));
      Assert.Equal(HttpStatusCode.Created, response.StatusCode);

      var user = await GetUserAsync(createUserCommand.Email);
      Assert.Equal(user.Email, createUserCommand.Email);
    }

    private async Task<UserDto> GetUserAsync(string email) {
      var response = await _factory.CreateClient().GetAsync($"/users/{email}");
      var responseString = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<UserDto>(responseString);
    }

    private static StringContent GetPayload(object data)
    {
      var json = JsonConvert.SerializeObject(data);
      return new StringContent(json, Encoding.UTF8, "application/json");
    }
  }
}
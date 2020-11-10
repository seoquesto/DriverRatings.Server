using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Api.Controllers;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Services;

namespace DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ApiControllerBase
  {
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService, ICommandDispatcher commandDispatcher)
      : base(commandDispatcher)
    {
      this._usersService = usersService;
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetAsync(string email)
    {
      var user = await this._usersService.GetByEmailAsync(email);
      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }
  }
}

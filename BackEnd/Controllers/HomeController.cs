using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost(Name = "LoginUser")]
        public IActionResult LoginUser([FromBody] User content)
        {
            var user = _userService.createUser(content.firstName, content.lastName, content.email);
            return new OkObjectResult(user);
        }
    }
}

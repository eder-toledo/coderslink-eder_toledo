using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost(Name = "LoginUser")]
        public IActionResult LoginUser([FromBody] User content)
        {
            return new OkObjectResult(content);
        }
    }
}

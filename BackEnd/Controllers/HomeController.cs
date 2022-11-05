using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost(Name = "LoginUser")]
        public IActionResult LoginUser()
        {
            return new OkObjectResult(new { message = "ok" });
        }

        
    }
}

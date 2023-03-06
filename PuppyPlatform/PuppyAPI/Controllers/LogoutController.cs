using Microsoft.AspNetCore.Mvc;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LogoutController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}

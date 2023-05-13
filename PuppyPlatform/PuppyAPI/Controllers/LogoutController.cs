using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LogoutController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}

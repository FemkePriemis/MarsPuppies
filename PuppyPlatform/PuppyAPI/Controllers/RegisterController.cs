using Microsoft.AspNetCore.Mvc;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Database;
using PuppyAPI.Logic;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    

    public class LoginController : ControllerBase
    {
        TokenHandling th = new TokenHandling();

        private readonly DatabaseContext _DbContext;

        public LoginController(DatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Index(string username, string password)
        {

            var user = _DbContext.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return Unauthorized();
            }

            //Store a password hash:
            PasswordHash hash = new PasswordHash(user.Salt, password);
            byte[] hashBytes = hash.ToArray();

            if (hashBytes.SequenceEqual(user.Password))
            {
                // Create token
                string tokenString = th.GenerateToken(user);
                return Ok(new { Token = tokenString });
            }


            return Unauthorized();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Database;
using PuppyAPI.Logic;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PuppyAPI.Database.EFmodels;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    

    public class LoginController : ControllerBase
    {
        
        private readonly DatabaseContext _DbContext;
        TokenHandling th = new TokenHandling();

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
                // Create token(s)
                string refreshtoken = Request.Cookies["refreshToken"];
                
                var response = RefreshingToken(refreshtoken, user);

                // Send tokens in response
                return Ok(response);
            }

            return Unauthorized();
        }

        public class TokenResponse
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }

        private TokenResponse RefreshingToken(string refreshToken, EFUser user)
        {
            if (user == null)
            {
                return null;
            }
            var userId = user.UserGUID;

            // Check if the refresh token is valid and retrieve the user associated with it
            var isValid = ValidateRefreshToken(refreshToken, user.UserGUID);
            if (isValid)
            {
                // Invalidate old refresh tokens for the user
                _DbContext.RefreshTokens
                    .RemoveRange(_DbContext.RefreshTokens.Where(rt => rt.UserGUID == userId));
                _DbContext.SaveChanges();
            }

            // Generate new access token and refresh token
            string newAccessToken = th.GenerateToken(user);
            string newRefreshToken = th.GenerateRefrToken(user);

            // Store the new refresh token in the database
            _DbContext.RefreshTokens.Add(new EFRefreshToken { User = user, Token = newRefreshToken });
            _DbContext.SaveChanges();

            return new TokenResponse { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
        }

        private bool ValidateRefreshToken(string refreshToken, Guid userId)
        {
          
            // Check if the refresh token is valid and retrieve the user associated with it
            var isValid = false;

            //check whether there's a token for the username
            var tokenfound =_DbContext.RefreshTokens.FirstOrDefault(r => r.UserGUID == userId);
            if (tokenfound == null)
            {
                return false;
            }

            if (refreshToken == null){
                return true; //there's a token but not saved in the cookies probably
            }

            isValid = tokenfound.Token == refreshToken;

            return isValid;
        }

        [HttpGet]
        [Route("AccessTokenValidation")]
        public bool validateAccessToken(string token)
        {
            return th.ValidateCurrentToken(token);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PuppyPlatform.Models
{
    public class LoginView
    {
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public class TokenResponse
            {
                public string AccessToken { get; set; }
                public string RefreshToken { get; set; }
            }

            [BindProperty]
            public string errorMessage { get; set; }
        }


    }
}
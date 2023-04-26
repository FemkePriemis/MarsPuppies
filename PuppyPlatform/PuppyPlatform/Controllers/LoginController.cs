using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static PuppyPlatform.Models.LoginView;

namespace PuppyPlatform.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            // Send an HTTP request to the authentication service to check the user's credentials
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7117/Login?username={model.Username}&password={model.Password}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var accessToken = JsonConvert.DeserializeObject<string>(data);


                    // Store the access token in a cookie
                    Response.Cookies.Append("accessToken", accessToken, new CookieOptions
                    {
                        Path = "/",
                        Secure = true,
                        HttpOnly = true,
                        SameSite = SameSiteMode.None
                    });

                    // Redirect to the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    return View();
                }
            }
        }
    }
}

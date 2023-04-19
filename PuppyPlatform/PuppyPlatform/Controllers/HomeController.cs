using Microsoft.AspNetCore.Mvc;
using PuppyPlatform.Models;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Net.Http.Headers;

namespace PuppyPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {

            string accesstoken = Request.Cookies["accessToken"];
            

            if (accesstoken == null)
            {
                return RedirectToAction("Login");
            }

            bool validtoken = IsAccessTokenValid(accesstoken);

            if (!validtoken)
            {
                return RedirectToAction("Login");
            }

            // Show the index page
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            string accesstoken = Request.Cookies["accessToken"];


            if (accesstoken == null)
            {
                return RedirectToAction("Login");
            }

            bool validtoken = IsAccessTokenValid(accesstoken);

            if (!validtoken)
            {
                return RedirectToAction("Login");
            }

            var model = new ErrorViewModel();
            model.RequestId = "TEST";
            return View(model);
        }

        public IActionResult Logout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool IsAccessTokenValid(string accessToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = client.GetAsync("https://localhost:7117/Login/AccessTokenValidation/?token=" + accessToken);
            response.Wait(); // wait for the response to complete

            return response.Result.IsSuccessStatusCode;
        }
    }
}
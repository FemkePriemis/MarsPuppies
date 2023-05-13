using Microsoft.AspNetCore.Mvc;
using PuppyPlatform.Models;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
            var model = new IndexController();

            return model.Index(accesstoken);

        }
        public IActionResult Login()
        {
            var loginC = new LoginController();

            return loginC.Index();
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

            var model = new DashboardModel();
            model.accessToken = accesstoken;

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
        public string GetRandomDogImageUrl() //TODO make async
        {
            const string apiKey = "AIzaSyDxgheVd9NBahpJLoTD0g2cn_-P03d1cHQ";
            const string cseId = "512209ef6eb744047";

            var rand = new Random().Next(100);
            var url = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cseId}&searchType=image&q=working+dog&num=1&start={rand}&imgSize=large";

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                var data = JsonConvert.DeserializeObject<dynamic>(response);
                var imageUrl = data.items[0].link;
                return imageUrl;
            }
        }

    }
}
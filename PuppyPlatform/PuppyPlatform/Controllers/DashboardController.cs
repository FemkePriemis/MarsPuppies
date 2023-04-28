using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static PuppyPlatform.Models.DashboardModel;

namespace PuppyPlatform.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<Dictionary<string, int>> GetDogHealthStatusCountsAsync(string accesstoken)
        {
            // Call the API endpoint to retrieve the list of dogs
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // add the access token to the Authorization header
            var healthstatussesResponse = await client.GetAsync("https://localhost:7117/Dog/HealthstateOptions");
            var healthstatusses = await healthstatussesResponse.Content.ReadFromJsonAsync<List<string>>();

            var dogsResponse = await client.GetAsync("https://localhost:7117/Dog");
            var dogs = await dogsResponse.Content.ReadFromJsonAsync<List<string>>();

            var healthStatusCount = new Dictionary<string, int>();
            foreach (var dog in dogs)
            {
                var dogIDResponse = await client.GetAsync($"https://localhost:7117/Dog/GetID?name={dog}");
                if (!dogIDResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Network response was not ok");
                }
                var dogID = await dogIDResponse.Content.ReadAsStringAsync();
                var healthResponse = await client.GetAsync($"https://localhost:7117/Dog/{dogID}/health");
                if (!healthResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Network response was not ok");
                }
                var dogHealth = await healthResponse.Content.ReadAsStringAsync();
                if (!healthStatusCount.ContainsKey(dogHealth))
                {
                    healthStatusCount[dogHealth] = 1;
                }
                else
                {
                    healthStatusCount[dogHealth]++;
                }
            }

            Dictionary<string, int> seriesCounts = new Dictionary<string, int>();

            foreach (var status in healthstatusses)
            {
                if (healthStatusCount.ContainsKey(status))
                {
                    seriesCounts.Add(status, healthStatusCount[status]);
                }
                else
                {
                    seriesCounts.Add(status, 0);
                }
            }

            return seriesCounts;
        }

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, int>>> FetchAndCountDogs(string accesstoken)
        {
            var model = new Models.DashboardModel();
            model.HealthstatusSeries = new Dictionary<string, int>();

            var seriesCounts = await GetDogHealthStatusCountsAsync(accesstoken);
            return Ok(seriesCounts);
        }



        [HttpGet]
        public IActionResult getDataforDisplay(string accesstoken)
        {
            return View();
        }

        [HttpPost]
        public bool makeFakeData(string accesstoken, string dog, string dataType, int numEntries, DateTime startTime, DateTime endTime )
        {
            return true;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> getDogNames(string accesstoken)
        {
            var dogNames  = new List<string>();
            return dogNames;
        }
    }
}

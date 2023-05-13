using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace PuppyPlatform.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index(string accesstoken)
        {
            // Call the API endpoint to retrieve the list of dogs
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // add the access token to the Authorization header
            
            
            var response = client.GetAsync("https://localhost:7117/Dog").Result;

            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

                var json = response.Content.ReadAsStringAsync().Result;
            var dogs = JsonConvert.DeserializeObject<List<string>>(json);

            // Create the dashboard model and populate it with the dog data
            var model = new Models.IndexModel();
            model.Dogs = new List<Models.Dog>();


                foreach (var dog in dogs)
                {
                    // Retrieve the dog's description and image URL from the API endpoint
                    // Alternatively, you can store the description and image URL in a database
                    var description = "";
                    var imageUrl = "";
                    if (dog == "Yuka")
                    {
                        description = "The captain. He stands tall among others, despite his athletic frame. There's something fascinating about him, perhaps it's his tenderness or perhaps it's simply his odd friends. But nonetheless, the others tend to follow him, while trying to subtly look more like him.";
                        imageUrl = "Photos/Yuka.jpg";
                    }
                    else if (dog == "Aico")
                    {
                        description = "Very caring and takes care of the station's rations. Nearly impossible to wake up. He could sleep through a hurricane.";
                        imageUrl = "Photos/Aico.jpg";
                    }
                    else if (dog == "Jara")
                    {
                        description = "Has decided that all commonly retrieved food is poison to her body. This has her on edge with Aico.";
                        imageUrl = "Photos/Jara.jpg";
                    }

                    else
                    {
                        //generate a random new url from google
                        var newImageUrl = GetRandomDogImageUrl();

                        if (newImageUrl != null)
                        {
                            imageUrl = newImageUrl;
                        }

                        description = "To be done";
                    }

                    // Create a new dog object and add it to the list of dogs
                    var newDog = new Models.Dog
                    {
                        Name = dog,
                        Description = description,
                        ImageUrl = imageUrl
                    };
                    model.Dogs.Add(newDog);
                }


            // Pass the dashboard model to the view
            return View(model);
            
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

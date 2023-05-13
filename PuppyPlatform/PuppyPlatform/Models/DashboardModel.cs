using Microsoft.AspNetCore.Mvc;

namespace PuppyPlatform.Models
{
    
    public class DashboardModel
    {
        
        public Dictionary<string, int> HealthstatusSeries { get; set; }

        public string accessToken { get; set; } //scary but to make things work for now
    }


}
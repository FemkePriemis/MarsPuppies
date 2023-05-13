using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Database;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)] //The base is hidden so need to redefine
    public class HandlerController : RolesController
    {
        public HandlerController(DatabaseContext DbContext) : base(DbContext)
        {
        }


    }
}

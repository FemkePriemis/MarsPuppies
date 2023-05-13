using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Database;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)] //The base is hidden so need to redefine
    public class VetController : RolesController
    {
        public VetController(DatabaseContext DbContext) : base(DbContext)
        {
        }
    }
}

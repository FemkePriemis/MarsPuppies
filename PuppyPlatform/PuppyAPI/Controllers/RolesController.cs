using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Database;
using PuppyAPI.Database.EFmodels;
using PuppyAPI.Model;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)] // This is a base for others
    public class RolesController : Controller
    {
        private readonly DatabaseContext _DbContext;

        public RolesController(DatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }

        // GET: Handler or Vet
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(Guid Userguid) //get all the dogs that belong to that user
        {
            return Ok();
        }

        // POST: Add a dog
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("AddDog")]
        public ActionResult AddDog(string UserName, Guid DogGUID)
        {
            try
            {
                // Check if the role already exists in the database
                var existingUsername = _DbContext.Users.FirstOrDefault(r => r.UserName == UserName);
                

                //create a user in the database
                if (existingUsername == null)
                {
                    return BadRequest("User with username does not exist");
                }

                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == DogGUID);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                var userfound = _DbContext.Users.FirstOrDefault(r => r.UserName == UserName);

                if (userfound == null)
                {
                    return BadRequest("User with username does not exist");
                }

                var efRelation = new EFDogRelations
                {
                    UserGUID = userfound.UserGUID,
                    DogGUID = DogGUID
                };

                _DbContext.Relation.Add(efRelation);
                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest("Could not add relation");
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuppyAPI.Database;
using PuppyAPI.Database.EFmodels;
using PuppyAPI.Model;

using PuppyAPI.Logic;
using System.Security.Cryptography;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _DbContext;

        public UserController(DatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }

        // GET: Users
        [HttpGet]
        public ActionResult Index(int ID)
        {
            var user = _DbContext.Users.Find(ID);
            return Ok(user);
        }

        // POST: UsersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken] // typically used to help prevent cross-site request forgery (CSRF) attacks.
        public ActionResult Create(User user )
        {
            try
            {
                // Check if the role already exists in the database
                var existingUsername = _DbContext.Users.FirstOrDefault(r => r.UserName == user.UserName);

                //create a user in the database
                if (existingUsername != null)
                {
                    return BadRequest("User with username already exists");
                }

                // Check if the role already exists in the database
                var existingRole = DatabaseItemChecker.RoleFinder(user, _DbContext);


                //Store a password hash:
                PasswordHash hash = new PasswordHash(user.Password);
                byte[] hashBytes = hash.ToArray();
                byte[] saltBytes = hash.Salt;

                var efUser = new EFUser
                {
                    UserName = user.UserName,
                    Password = hashBytes,
                    //Role = new EFRole { RoleName = user.Role.RoleName }
                    Role = existingRole,
                    Salt = saltBytes
                };

                _DbContext.Users.Add(efUser);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                user.Id = efUser.UserGUID; //when creating the userID is incorrect/empty so set it now
                
                return Created($"/Index?id={user.Id}", user);
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }


        // POST: Users/Edit
        [HttpPut]
        //[ValidateAntiForgeryToken] // prevent cross-site request forgery (CSRF) attacks.
        public ActionResult Edit(User userToUpdate)
        {
            try
            {
                // Check if the role already exists in the database
                var existingRole = DatabaseItemChecker.RoleFinder(userToUpdate, _DbContext);


                //Store a password hash:
                PasswordHash hash = new PasswordHash(userToUpdate.Password);
                byte[] hashBytes = hash.ToArray();

                //create a user in the database
                var efUser = new EFUser
                {
                    UserGUID = (Guid)userToUpdate.Id, //Id is nullable but UserID isn't
                    UserName = userToUpdate.UserName,
                    Password = hashBytes,

                    ///Role = new EFRole { RoleName = userToUpdate.Role.RoleName }
                    Role = existingRole
                };

                _DbContext.Users.Update(efUser);
                _DbContext.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }


        [HttpDelete]
        //[ValidateAntiForgeryToken] // prevent cross-site request forgery (CSRF) attacks.
        public ActionResult Delete(int id)
        {
            try
            {
                var userToDelete = _DbContext.Users.Find(id);
                if (userToDelete == null)
                {
                    return NotFound();
                }
                _DbContext.Users.Remove(userToDelete);
                _DbContext.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }


        [HttpDelete]
        [Route("Role")]
        //[ValidateAntiForgeryToken] // prevent cross-site request forgery (CSRF) attacks.
        public ActionResult DeleteRole(int id)
        {
            try
            {
                var roleToDelete = _DbContext.Roles.Find(id);
                if (roleToDelete == null)
                {
                    return NotFound();
                }
                _DbContext.Roles.Remove(roleToDelete);
                _DbContext.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }


    }
}

using PuppyAPI.Database;
using PuppyAPI.Database.EFmodels;
using PuppyAPI.Model;

namespace PuppyAPI.Logic
{
    public class DatabaseItemChecker
    {

        public static EFRole RoleFinder(User userToValidate, DatabaseContext _DbContext)
        {
            // Check if the role already exists in the database
            var existingRole = _DbContext.Roles.FirstOrDefault(r => r.RoleName == userToValidate.Role.RoleName);

            // Create a new role if it doesn't already exist
            if (existingRole == null)
            {
                existingRole = new EFRole { RoleName = userToValidate.Role.RoleName };
                _DbContext.Roles.Add(existingRole);
                _DbContext.SaveChanges();
            }

            return existingRole;
        }
    }
}

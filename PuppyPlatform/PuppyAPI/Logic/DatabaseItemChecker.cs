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


        public static EFHealthStatus HealthFinder(Dog dogToValidate, DatabaseContext _DbContext)
        {
            // Check if the role already exists in the database
            var existingHS = _DbContext.HealthStatus.FirstOrDefault(r => r.Healthstate == dogToValidate.Healthstatus.Healthstate);

            // Create a new role if it doesn't already exist
            if (existingHS == null)
            {
                DateTime timeNow = DateTime.Now;
                existingHS = new EFHealthStatus { Healthstate = dogToValidate.Healthstatus.Healthstate, LastUpdated=timeNow};
                _DbContext.HealthStatus.Add(existingHS);
                _DbContext.SaveChanges();
            }

            return existingHS;

        }

        public static EFBehaviour BehaviourFinder(Dog dogToValidate, DatabaseContext _DbContext)
        {
            // Check if the role already exists in the database
            var existingHS = _DbContext.Behaviour.FirstOrDefault(r => r.UnusualBehaviour == dogToValidate.Behaviour.UnusualBehaviour);
            // Create a new role if it doesn't already exist
            if (existingHS == null)
            {
                DateTime timeNow = DateTime.Now;
                existingHS = new EFBehaviour { UnusualBehaviour = dogToValidate.Behaviour.UnusualBehaviour };
                _DbContext.Behaviour.Add(existingHS);
                _DbContext.SaveChanges();
            }

            return existingHS;

        }
    }
}

namespace PuppyAPI.Model
{
    public class User
    {
        public Guid? Id { get; set; } //allowed to initially be empty/null
        public string UserName { get; set; }
        public string Password { get; set; }
       // public string Salt { get; set; }

        public Role Role { get; set; }
        
    }

    public class Role //base class for Vet and Handler
    {
        public string RoleName { get; set; }
        public List<Guid>? DogIDs { get; set; } //? means can be null, the IDs of the dogs they can access
    }
}

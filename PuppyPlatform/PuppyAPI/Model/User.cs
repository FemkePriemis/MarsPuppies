namespace PuppyAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }

    public class Role //base class for Vet and Handler
    {
        public string Name { get; set; }
        public List<int>? DogIDs { get; set; } //? means can be null, the IDs of the dogs they can access
    }
}

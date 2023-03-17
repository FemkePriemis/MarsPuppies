namespace PuppyAPI.Database.EFmodels
{
    public class EFUser
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Password { get; set; }
        public int RoleID { get; set; }

    }

    public class EFRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
    }
    public class EFDogRelations
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int DogID { get; set; }
    }
}

namespace PuppyPlatform.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class IndexModel
    {
        public List<Dog> Dogs { get; set; }

    }

}
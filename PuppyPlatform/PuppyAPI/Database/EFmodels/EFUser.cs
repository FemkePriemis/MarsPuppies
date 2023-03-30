using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuppyAPI.Database.EFmodels
{
    public class EFUser
    {
        [Key]
        public Guid UserGUID { get; set; }
        public string UserName { get; set; }  
        public byte[] Password { get; set; } //has is > 8 hobbits

        public byte[] Salt { get; set; }
        public Guid RoleGUID { get; set; }
        [ForeignKey("RoleGUID")]
        public EFRole Role { get; set; }

    }

    public class EFRole
    {
        [Key]
        public Guid RoleGUID { get; set; }
        public string RoleName { get; set; }
    }
    public class EFDogRelations
    {
        [Key]
        public Guid DogrelationsGUID { get; set; }
        public Guid UserGUID { get; set; }
            [ForeignKey("UserGUID")]
            public EFUser User { get; set; }

        public Guid DogGUID { get; set; }
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PuppyAPI.Database.EFmodels;

namespace PuppyAPI.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<EFUser> Users { get; set;}
            public DbSet<EFRole> Roles { get; set;}
            
        public DbSet<EFDog> Dog { get; set;}
            public DbSet<EFHealthStatus> HealthStatus { get; set;}
            public DbSet<EFInjury> Injury { get; set;}
            public DbSet<EFMedication> Medication { get; set;}
            public DbSet<EFIllness> Illness { get; set;}

            public DbSet<EFBiometric> Biometric { get; set; }
            public DbSet<EFHeartrate> Heartrate { get; set;}
            public DbSet<EFTemperature> Temperature { get; set; }
            public DbSet<EFGrade> ActivityGrade { get; set; }
            public DbSet<EFBehaviour> Behaviour { get; set; }
            
        public DbSet<EFDogRelations> Relation { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> name) : base(name)
        {

        }
       /* TODO
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EFDog>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<EFBehaviour>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<EFDog>()
                .HasOne(p => p.Behaviour)
                .HasForeignKey(p => p.Id);
        }
       */
    }
}

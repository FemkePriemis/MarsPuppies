using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuppyAPI.Database.EFmodels
{
    public class EFDog
    {
        [Key]
        public Guid DogGUID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public Guid HealthstatusGUID { get; set; }
            [ForeignKey("HealthstatusGUID")]
            public EFHealthStatus  HealthStatus { get; set; }

        public Guid BiometricsGUID { get; set; }
            [ForeignKey("BiometricsGUID")]
            public EFBiometric Biometric { get; set; }

        public Guid BehaviourGUID { get; set; }
            [ForeignKey("BehaviourGUID")]
            public EFBehaviour Behaviour { get; set; }

    }

    public class EFHealthStatus
    {
        [Key]
        public Guid HealthstatusGUID { get; set; }

        public Guid HealthStateGUID { get; set; }
            [ForeignKey("HealthstateGUID")]
            public EFHealthstate Healthstate { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    public class EFHealthstate //'enum'
    {
        [Key]
        public Guid HealthstateGUID { get; set; }
        public string Healthstate { get; set; }
    }

    public class EFInjury
    {
        [Key]
        public Guid InjuryGUID { get; set; }
        public Guid DogID { get; set;}
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public string Injury { get; set; }
        public DateTime InjuryDate { get; set; }

    }

    public class EFMedication
    {
        [Key]
        public Guid MedicationGUID { get; set; }
        public Guid DogGUID { get; set;}
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public string Medication { get; set; }
        public DateTime PerscriptionDate { get; set;}
    }

    public class EFIllness
    {
        [Key]
        public Guid IllnessGUID { get; set; }
        public Guid DogGUID { get; set; }
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public string Illness { get; set; }
        public DateTime IllnessDate { get; set; }
    }

    public class EFBiometric
    {
        [Key]
        public Guid BiometricGUID { get; set; }
        public int HeartrateThreshold { get; set; }
        public double TemperatureThreshold { get; set; }
    }

    public class EFHeartrate
    {
        [Key]
        public Guid HeartrateGUID { get; set; }
        public Guid DogGUID { get; set;}
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public DateTime HeartrateDate { get; set;}
        public int Heartrate { get; set; }
    }

    public class EFTemperature
    {
        [Key]
        public Guid TemperatureGUID { get; set; }
        public Guid DogGUID { get; set; }
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public DateTime TemperatureDate { get; set; }
        public double Temperature { get; set; }
    }

    public class EFBehaviour
    {
        [Key]
        public Guid BehaviourGUID { get; set; }
        public string UnusualBehaviour { get; set; }
    }

    public class EFGrade
    {
        [Key]
        public Guid GradeGUID { get; set; }
        public Guid DogGUID { get; set;}
            [ForeignKey("DogGUID")]
            public EFDog Dog { get; set; }
        public DateTime GradeDate { get; set; }
        public double Grade { get; set; }
        public string Subject { get; set; }
    }

}

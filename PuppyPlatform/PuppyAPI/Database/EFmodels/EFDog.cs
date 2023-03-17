namespace PuppyAPI.Database.EFmodels
{
    public class EFDog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; } 
        public int Age { get; set; }
        public int Weight { get; set; }
        public int HealthstatusID { get; set; }
        public int BiometricsID { get; set; }
        public int BehaviourID { get; set; }

        //public virtual EFBehaviour Behaviour { get; set; } //TODO

    }

    public class EFHealthStatus
    {
        public int Id { get; set; }
        public string HealthState { get;set; }
        public DateTime LastUpdated { get; set; }
    }

    public class EFInjury
    {
        public int Id { get; set; }
        public int DogID { get; set;}
        public string Injury { get; set; }
        public DateTime InjuryDate { get; set; }

    }

    public class EFMedication
    {
        public int Id { get; set; }
        public int DogID { get; set;}
        public string Medication { get; set; }
        public DateTime PerscriptionDate { get; set;}
    }

    public class EFIllness
    {
        public int Id { get; set; }
        public int DogID { get; set; }
        public string Illness { get; set; }
        public DateTime IllnessDate { get; set; }
    }

    public class EFBiometric
    {
        public int Id { get; set; }
        public int HeartrateThreshold { get; set; }
        public double TemperatureThreshold { get; set; }
    }

    public class EFHeartrate
    {
        public int Id { get; set; }
        public int DogID { get; set;}
        public DateTime HeartrateDate { get; set;}
        public int Heartrate { get; set; }
    }

    public class EFTemperature
    {
        public int Id { get; set; }
        public int DogID { get; set; }
        public DateTime TemperatureDate { get; set; }
        public double Temperature { get; set; }
    }

    public class EFBehaviour
    {
        public int Id { get; set; }
        public string UnusualBehaviour { get; set; }

        //public virtual EFDog EFDog { get; set; } //TODO 1-1 relationship
    }

    public class EFGrade
    {
        public int Id { get; set; }
        public int DogID { get; set;}
        public DateTime GradeDate { get; set; }
        public double Grade { get; set; }
        public string Subject { get; set; }
    }

}

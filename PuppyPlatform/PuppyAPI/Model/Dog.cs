
using Newtonsoft.Json;

using JOS.Enumeration.Ours; //for enums

namespace PuppyAPI.Model
{
    public class Dog
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }

        public int Weight { get; set; }

        public Healthstatus Healthstatus { get; set; }

        public Biometrics Biometrics { get; set; }
        public Behaviour Behaviour { get; set; }
    }

    public class Healthstatus
    {
        public string Healthstate { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string>? Injuries { get; set; } 
        public List<string>? Medications { get; set; }
        public List<string>? Illnesses { get; set; }


    }

    public class Biometrics
    {
        public List<int>? Heartrate { get; set; }//? means nullable
        public int HeartrateThreshold { get; set; }
        public List<double>? Temperature { get; set; }//? means nullable
        public double TemperatureThreshold { get; set; }

        public List<Grades>? ActivityGrades { get; set;}
        
    }

    public class Behaviour
    {
        public List<Grades>? SleepGrades { get; set; }
        public string UnusualBehaviour { get; set; }
    }

    public class Grades
    {
        public DateTime DateTime { get; set; }
        public int Grade { get; set; }
    }
   
}

using Newtonsoft.Json;

namespace PuppyAPI.Model
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }

        public int weight { get; set; }

        public Healthstatus Healthstatus { get; set; }

        public Biometrics Biometrics { get; set; }
        public Behaviour Behaviour { get; set; }


    }

    public class Healthstatus
    {

        
        public enum HEALTHSTATUS//how do I make this viewable in Swagger?
        {
           HEALTHY,
           MEDICATED,
           INJURED,
           PREGNANT
        }


        public HEALTHSTATUS Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string>? Injuries { get; set; } 
        public List<string>? Medications { get; set; }
        public List<string>? Illnesses { get; set; }


    }

    public class Biometrics
    {
        public List<int>? Heartrate { get; set; }//? means nullable
        public int HeartrateThreshold { get; set; }
        public List<int>? Temperature { get; set; }//? means nullable
        public int TemperatureThreshold { get; set; }

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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuppyAPI.Database;
using PuppyAPI.Database.EFmodels;
using PuppyAPI.Logic;
using PuppyAPI.Model;
using System.Net;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {


        private readonly DatabaseContext _DbContext;

        public DogController(DatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }


        [HttpGet]
        public ActionResult Index() //returns all dog names
        {
            List<string> dogNames = _DbContext.Dog.Select(x => x.Name).ToList();
            return Ok(dogNames);
        }

        [HttpGet]
        [Route("GetID")]
        public ActionResult GetDogID(string name)
        {
            try
            {
                // Check if the dog already exists in the database
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.Name == name);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with name does not exist");
                }

                else
                {
                    return Ok(existingDog.DogGUID);
                }
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPost]
        public ActionResult Add(Dog dog)
        {
            try
            {
                // Check if the dog already exists in the database
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.Name == dog.Name);

                //create a user in the database
                if (existingDog != null)
                {
                    return BadRequest("Dog with name & age combination already exists");
                }

                var existingHealthstatus = DatabaseItemChecker.HealthFinder(dog, _DbContext);
                var existingBehaviour = DatabaseItemChecker.BehaviourFinder(dog, _DbContext);

                DateTime timeNow = DateTime.Now;

                var efDog = new EFDog
                {
                    Name = dog.Name,
                    Age = dog.Age,
                    Gender = dog.Gender,
                    Weight = dog.Weight,

                    //health status
                    HealthStatus = existingHealthstatus,
                    //Biometrics
                    Biometric = new EFBiometric { HeartrateThreshold = dog.Biometrics.HeartrateThreshold, TemperatureThreshold = dog.Biometrics.TemperatureThreshold },
                    //Behaviour
                    Behaviour = existingBehaviour
                };

                _DbContext.Dog.Add(efDog);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                dog.Id = efDog.DogGUID; //when creating the userID is incorrect/empty so set it now

                return Created($"/Index?id={dog.Id}", dog);
            }
            catch
            {
                return BadRequest("Invalid data. Could not add dog.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {

            try
            {
                var dogToDelete = _DbContext.Dog.Find(id);
                if (dogToDelete == null)
                {
                    return NotFound();
                }
                _DbContext.Dog.Remove(dogToDelete);
                _DbContext.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut]
        public ActionResult UpdateDog(Dog dog)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.Biometric).FirstOrDefault(r => r.DogGUID == dog.Id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                DateTime timeNow = DateTime.Now;

                existingDog.DogGUID = dog.Id;
                existingDog.Name = dog.Name;
                existingDog.Gender = dog.Gender;
                existingDog.Age = dog.Age;

                var existingHealthstatus = DatabaseItemChecker.HealthFinder(dog, _DbContext);
                var existingBehaviour = DatabaseItemChecker.BehaviourFinder(dog, _DbContext);

                
                existingDog.HealthStatus = existingHealthstatus; //Todo: make this not make a new one every time

                var biometrics = new EFBiometric { HeartrateThreshold = dog.Biometrics.HeartrateThreshold, TemperatureThreshold = dog.Biometrics.TemperatureThreshold };

                if (dog.Biometrics.TemperatureThreshold != existingDog.Biometric.TemperatureThreshold)
                {
                    biometrics = existingDog.Biometric;
                }

                //Biometrics
                existingDog.Biometric = biometrics;
                
                //Behaviour
                existingDog.Behaviour = existingBehaviour;

                _DbContext.Dog.Update(existingDog);
                _DbContext.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }

        /*Health*/
        [HttpGet]
        [Route("HealthstateOptions")]
        public ActionResult ReturnHealthoptions()
        {
            var options = _DbContext.HealthStatus.Select(x => x.Healthstate).ToList();
            return Ok(options);
        }

        [HttpGet("{id}/health")]
        public ActionResult test(Guid id)
        {

            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.HealthStatus).FirstOrDefault(r => r.DogGUID == id); //the include is needed because of lazy loading

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

               var healthstatus = existingDog.HealthStatus.Healthstate;

                return Ok(healthstatus);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
            
        }

        [HttpPost("{id}/health/injuries")]
        public ActionResult injuries(Guid id, string Injury, DateTime InjuryDate)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                var efInjury = new EFInjury
                {
                    Injury = Injury,
                    InjuryDate = InjuryDate,
                    DogGUID = id
                };

                _DbContext.Injury.Add(efInjury);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPost("{id}/health/illnesses")]
        public ActionResult illnesses(Guid id, string Illness, DateTime IllnessDate)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                var efIllness = new EFIllness
                {
                    Illness = Illness,
                    IllnessDate = IllnessDate,
                    DogGUID = id
                };

                _DbContext.Illness.Add(efIllness);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPost("{id}/health/medications")]
        public ActionResult medications(Guid id, string MEdication, DateTime AssignDate)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                var efMeds = new EFMedication
                {
                    Medication = MEdication,
                    PerscriptionDate = AssignDate,
                    DogGUID = id
                };

                _DbContext.Medication.Add(efMeds);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }


        [HttpGet("{id}/health/medications")]
        public ActionResult gmedications(Guid id)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                // Check if the role already exists in the database
                var existingMeds = _DbContext.Medication.Where(r => r.DogGUID == id).Select(r => r.Medication).ToList();

                //create a user in the database
                if (existingMeds == null)
                {
                    return BadRequest("Dog with this GUID does not have medications");
                }

                return Ok(existingMeds);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        ActionResult updateGrade(Guid id, string subject, float grade)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }
                DateTime timeNow = DateTime.Now;

                var efMGrade = new EFGrade
                {
                    Grade = grade,
                    GradeDate = timeNow,
                    Subject = subject,
                    DogGUID = id
                };

                _DbContext.Grades.Add(efMGrade);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        /*Behaviour*/
        [HttpPost("{id}/behaviour/sleepGrade")]
        public ActionResult sleeppattern(Guid id, float grade)
        {
            string subject = "Sleep";

            return updateGrade(id, subject, grade);
        }

        [HttpPost("{id}/behaviour/activityGrade")]
        public ActionResult activitypattern(Guid id, float grade)
        {
            string subject = "Activity";

            return updateGrade(id, subject, grade);
        }

        [HttpPut("{id}/behaviour/unusualBehaviour")]
        public ActionResult unusBehaviour(Guid id, string behaviour)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.Behaviour).FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }
                
                // Check if the role already exists in the database
                var existingBehaviour = _DbContext.Behaviour.FirstOrDefault(r => r.UnusualBehaviour == behaviour);
                // Create a new role if it doesn't already exist
                if (existingBehaviour == null)
                {
                    DateTime timeNow = DateTime.Now;
                    existingBehaviour = new EFBehaviour { UnusualBehaviour = behaviour };
                    _DbContext.Behaviour.Add(existingBehaviour);
                    _DbContext.SaveChanges();
                }


                //Behaviour
                existingDog.Behaviour = existingBehaviour;

                _DbContext.Dog.Update(existingDog);
                _DbContext.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpGet("{id}/behaviour")]
        public ActionResult test2(Guid id)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.Behaviour).FirstOrDefault(r => r.DogGUID == id); //the include is needed because of lazy loading

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                var behaviour = existingDog.Behaviour.UnusualBehaviour;

                return Ok(behaviour);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }


        ActionResult getGrades(Guid id, string subject)
        {
            try
            {
                // Check if the role already exists in the database
                var existingGrades = _DbContext.Grades.Where(r => r.DogGUID == id && r.Subject == subject).ToList();

                //create a user in the database
                if (existingGrades == null)
                {
                    return BadRequest("Dog with this GUID does not have grades");
                }


                return Ok(existingGrades);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpGet("{id}/behaviour/sleepGrade")]
        public ActionResult gsleeppattern(Guid id)
        {
            string subject = "Sleep";
            return getGrades(id, subject);
        }

        [HttpGet("{id}/behaviour/activityGrade")]
        public ActionResult gactivitypattern(Guid id)
        {
            string subject = "Activity";
            return getGrades(id, subject);
        }


        /*Biometrics*/

        [HttpGet("{id}/biometricThresholds")]
        public ActionResult test3(Guid id)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d=> d.Biometric).FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }


                var biometrics = existingDog.Biometric;

                if (biometrics == null)
                {
                    BadRequest("No biometrics for this dog");
                }
                return Ok(biometrics);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPost("{id}/biometrics/heartrates")]
        public ActionResult hr2(Guid id, int heartrate, DateTime? possTime = null)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }
                DateTime timeNow;

                if (possTime == null)
                {
                    timeNow = DateTime.Now;
                }
                else
                {
                    timeNow = (DateTime)possTime;
                }

                var efHR = new EFHeartrate
                {
                    Heartrate = heartrate,
                    HeartrateDate = timeNow,
                    DogGUID = id
                };

                _DbContext.Heartrate.Add(efHR);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPost("{id}/biometrics/temperatures")]
        public ActionResult temp2(Guid id, float temp, DateTime? possTime = null)
        {
            try
            {
                var existingDog = _DbContext.Dog.FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }

                DateTime timeNow;


                if (possTime == null)
                {
                    timeNow = DateTime.Now;
                }
                else
                {
                    timeNow = (DateTime)possTime;
                }

                var efT = new EFTemperature
                {
                    Temperature = Math.Round(temp, 2),
                    TemperatureDate = timeNow,
                    DogGUID = id
                };

                _DbContext.Temperature.Add(efT);

                _DbContext.SaveChanges(); //await _DbContext.SaveChangesAsync();

                return Ok();

            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpGet("{id}/biometrics/heartrates")]
        public ActionResult ghr2(Guid id)
        {
            try
            {
                // Check if the role already exists in the database
                var existingRates = _DbContext.Heartrate.Where(r => r.DogGUID == id).ToList();

                //create a user in the database
                if (existingRates == null)
                {
                    return BadRequest("Dog with this GUID does not have grades");
                }


                return Ok(existingRates);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpGet("{id}/biometrics/temperatures")]
        public ActionResult gtemp2(Guid id)
        {
            try
            {
                // Check if the role already exists in the database
                var existingTs = _DbContext.Temperature.Where(r => r.DogGUID == id).ToList();

                //create a user in the database
                if (existingTs == null)
                {
                    return BadRequest("Dog with this GUID does not have grades");
                }


                return Ok(existingTs);
            }
            catch
            {
                return BadRequest("Invalid data");
            }
        }

        [HttpPut("{id}/biometrics/heartrateThreshold")]
        public ActionResult hr3(Guid id, int heartrateTh)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.Biometric).FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }


                existingDog.Biometric.HeartrateThreshold = heartrateTh;
                _DbContext.Dog.Update(existingDog);
                _DbContext.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }

        [HttpPut("{id}/biometrics/temperatureThreshold")]
        public ActionResult temp3(Guid id, float tempThr)
        {
            try
            {
                // Check if the role already exists in the database
                var existingDog = _DbContext.Dog.Include(d => d.Biometric).FirstOrDefault(r => r.DogGUID == id);

                //create a user in the database
                if (existingDog == null)
                {
                    return BadRequest("Dog with this GUID does not exist");
                }


                existingDog.Biometric.TemperatureThreshold = tempThr;
                _DbContext.Dog.Update(existingDog);
                _DbContext.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest("Invalid data.");
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Model;
using System.Net;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "test";
        }
        [HttpPost]
        public string Add(Dog s)
        {
            return s.Name + s.Name;
        }

        [HttpDelete]
        public string Add2(Dog s)
        {
            return s.Name + s.Name;
        }

        [HttpPost]
        [Route("{id}")]
        public string AddTwice(Dog s)
        {
            return s.Name + s.Name;
        }

        [HttpPut]
        [Route("{id}")]
        public bool Delete(char x)
        {
            return true;
        }

        [HttpGet]
        [Route("{id}/health")]
        public IActionResult test()
        {
            return Ok();
        }

        [HttpGet]
        [Route("healthstates")]
        //[ProducesResponseType(typeof(IEnumerable<Healthstatus.Healthstate>), (int)HttpStatusCode.OK)]
        public IActionResult GetHealthStates()
        {
            /* return Ok(new[]
             {
                 Healthstatus.Healthstate.Healthy, //probably only want the description string to be send
                 Healthstatus.Healthstate.Medicated,
                 Healthstatus.Healthstate.Injured,
                 Healthstatus.Healthstate.Pregnant,
         });*/
            return Ok();
        }

        [HttpPost]
        [Route("{id}/health/injuries")]
        public IActionResult injuries()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/health/illnesses")]
        public IActionResult illnesses()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/health/medications")]
        public IActionResult medications()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/behaviour")]
        public IActionResult test2()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/behaviour/sleepPattern")]
        public IActionResult sleeppattern()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/behaviour/unusualBehaviour")]
        public IActionResult unusBehaviour()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/biometrics")]
        public IActionResult test3()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/biometrics/heartrates")]
        public IActionResult hr2()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/biometrics/temperatures")]
        public IActionResult temp2()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}/biometrics/heartrateThreshold")]
        public IActionResult hr3()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}/biometrics/temperatureThreshold")]
        public IActionResult temp3()
        {
            return Ok();
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Model;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "test";
        }
        [HttpPost]
        [Route("Add")]
        public string Add(Dog s)
        {
            return s.Name + s.Name;
        }

        [HttpDelete]
        [Route("Remove")]
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
        [Route("{id}/Update")]
        public bool Delete(char x)
        {
            return true;
        }

        [HttpGet]
        [Route("{id}/Health")]
        public IActionResult test()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Health/Injuries")]
        public IActionResult injuries()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Health/Illnesses")]
        public IActionResult illnesses()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Health/Medications")]
        public IActionResult medications()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/Behaviour")]
        public IActionResult test2()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Behaviour/Sleeppattern")]
        public IActionResult sleeppattern()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Behaviour/UnusualBehaviour")]
        public IActionResult unusBehaviour()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/Biometrics")]
        public IActionResult test3()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Biometrics/Heartrates")]
        public IActionResult hr2()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Biometrics/Temperatures")]
        public IActionResult temp2()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Biometrics/HeartrateThreshold")]
        public IActionResult hr3()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/Biometrics/TemperatureThreshold")]
        public IActionResult temp3()
        {
            return Ok();
        }


    }
}

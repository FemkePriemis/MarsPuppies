using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuppyAPI.Model;

namespace PuppyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // GET: HandlerController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        // POST: HandlersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public string handlerinfo()
        {
            return "ok";
        }

        // POST: HandlerController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

    }
}

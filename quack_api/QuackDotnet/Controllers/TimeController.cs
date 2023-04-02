using Microsoft.AspNetCore.Mvc;

namespace Quack.Controllers
{
    [Route("api/time")]
    [ApiController]

    public class TimeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> GetTime(){
             DateTime localDate = DateTime.Now;
            return Ok( 
                new {response =  localDate}
            );
        }
    }
}
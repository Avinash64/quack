using Microsoft.AspNetCore.Mvc;

namespace Quack.Controllers
{
    [Route("api/choice")]
    [ApiController]

    public class ChoiceController : ControllerBase
    {
        [HttpPost]
        public ActionResult<object> PostChoice(List<string> choices){
        using var db = new QuackContext();
        Console.WriteLine("Inserting a new blog");
        var response = choices[Random.Shared.Next(choices.Count)];
db.Add(new Review { Body = response});
db.SaveChanges();

Console.WriteLine("Querying for a blog");
var blog = db.Reviews
    .OrderBy(b => b.ReviewId)
    .First();
    Console.WriteLine(blog.Body);
            return Ok( 
                new {response = response}
            );
        }
    }
}
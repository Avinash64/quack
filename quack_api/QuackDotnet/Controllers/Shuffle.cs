using Microsoft.AspNetCore.Mvc;

namespace Quack.Controllers;

[ApiController]
[Route("[controller]")]
public class ShuffleController : ControllerBase
{
    
    private string[]? Answers;
    [HttpPost(Name = "GetShuffle")]
    public Shuffle post(Shuffle bruh)
    {
        Console.WriteLine(bruh.Answer);
    var rnd = new Random();
        return new Shuffle {
            Answer = bruh.Answer.OrderBy(item => rnd.Next()).ToList()
        };

    }
}
using Microsoft.AspNetCore.Mvc;

namespace Quack.Controllers;


public class Roll
{
    public List<int>? roll { get; set; }
}


[ApiController]
[Route("[controller]")]
public class RollController : ControllerBase
{

    private readonly ILogger<MCSController> _logger;

    public RollController(ILogger<MCSController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRoll")]
    public Roll Get([FromQuery] int num = 1)
    {
        var rnd = new Random();
        List<int> dice = new List<int>();

        for (int i = 0; i < num; i++){
            dice.Add(rnd.Next(1, 7));
        }

        return new Roll
        {
            roll = dice
        };

      
    }
}

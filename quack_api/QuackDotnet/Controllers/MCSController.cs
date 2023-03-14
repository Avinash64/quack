using Microsoft.AspNetCore.Mvc;

namespace Quack.Controllers;

[ApiController]
[Route("api/mcs")]
public class MCSController : ControllerBase
{   
    [HttpGet]
    public ActionResult<string> GetMCS()
    {
    string[] Answers = new []
    {
        "As I see it, yes.", "Ask again later.", "Better not tell you now.", "Cannot predict now.", "Concentrate and ask again.", "Don’t count on it.", "It is certain.", "It is decidedly so.", "Most likely.", "My reply is no.", "My sources say no.", "Outlook not so good.", "Outlook good.", "Reply hazy, try again.", "Signs point to yes.", "Very doubtful.", "Without a doubt.","Yes.", "Yes - definitely.", "You may rely on it.", "Maybe someday.", "Nothing.", "Neither.", "I don't think so.", "Yes.", "Try asking again.", "No."
    };
        return Answers[Random.Shared.Next(Answers.Length)];
    }
}

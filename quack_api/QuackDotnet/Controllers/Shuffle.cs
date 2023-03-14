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
        return new Shuffle
        {
            Answer = bruh.Answer.OrderBy(item => rnd.Next()).ToList()
        };

    }
}

[ApiController]
[Route("[controller]")]
public class CoinFlipController : ControllerBase
{

    private object[]? Answers;
    [HttpGet(Name = "GetCoinFlip")]
    public string get()
    {
        var rnd = new Random();
        return new[] { "h", "t" }[rnd.Next(2)];


    }
}


public class WCC
{
    public Dictionary<string, List<string>>? data { get; set; }
};


[ApiController]
[Route("[controller]")]
public class WccController : ControllerBase
{
    [HttpPost(Name = "PostWcc")]
    public object post(WCC data)
    {
        Dictionary<string, Dictionary<string, Dictionary<string, int>>> wc = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
        List<string> keyList = new List<string>(data.data.Keys);
        foreach (string person in keyList)
        {
            Console.WriteLine(person);
            foreach (string i2 in data.data[person])
            {
                string[] sentence = i2.Split(' ');
                for (int i = 0; i < sentence.GetLength(0) - 1; i++)
                {
                    string word = sentence[i].ToLower();
                    if (i < sentence.GetLength(0) - 1 && word != "")
                    {
                        if (wc.Keys.Contains(person))
                        {
                            if (wc[person].Keys.Contains(word))
                            {
                                if (wc[person][word].Keys.Contains(sentence[i + 1]))
                                {
                                    wc[person][word][sentence[i + 1]]++;
                                }
                                else
                                {
                                    wc[person][word].Add(sentence[i + 1], 1);
                                }
                            }
                            else
                            {
                                var d = new Dictionary<string, int>() { { sentence[i + 1], 1 } };
                                wc[person].Add(word, d);
                            }
                        }
                        else
                        {
                            wc.Add(person, new Dictionary<string, Dictionary<string, int>>() { { word, new Dictionary<string, int>() { { sentence[i + 1], 1 } } } });
                        }
                    }
                }
            }
        }
        return wc;

    }
}
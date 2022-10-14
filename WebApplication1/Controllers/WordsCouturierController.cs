using Microsoft.AspNetCore.Mvc;
using PrivateLibrary;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsCouturierController : ControllerBase
{
    [HttpPost]
    public Dictionary<string, int> Get([FromBody]string[] allText)
    {
        return new WordsCounter().WordsCounterFromPathFileParallel(allText);
    }
}
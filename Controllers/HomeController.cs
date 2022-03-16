using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SunAPI.Logic;
using SunAPI.Models;

namespace SunAPI.Controllers
{    
    [ApiController]
    [Route("sun")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("sunset")]
        public OutputDto GetSunset([FromBody] InputDto input)
        {
            return new LogicSun().calculateSunset(input);
        }

        [HttpPost("sunrise")]
        public OutputDto GetSunrise([FromBody] InputDto input)
        {
            return new LogicSun().calculateSunrise(input);
        }

    }
}

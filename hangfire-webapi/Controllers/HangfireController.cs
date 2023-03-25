using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace hangfire_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hang fire web api!");
        }

        [HttpPost]
        [Route("[action]")]

        public IActionResult Discount()
        {
            int timeInSeconds = 30;

            var JobId = BackgroundJob.Schedule(() => SendWelcomeEmail("Welcome to our app!"), TimeSpan.FromSeconds(timeInSeconds));

            return Ok($"Job ID: {JobId}. Discount email will be sent in {timeInSeconds} seconds!");


        }
       

        private void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);

            Console.WriteLine(DateTime.UtcNow);
        }
        
    }
}
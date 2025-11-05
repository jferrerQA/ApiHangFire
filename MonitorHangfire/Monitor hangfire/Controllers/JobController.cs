using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monitor_hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpPost]
        [Route("CreateBackgroundJob")]
        public ActionResult CreateBackgroundJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Background Job Triggered"));
            return Ok();
        }


        [HttpPost]
        [Route("CreateScheduledJob")]
        public ActionResult CreateScheduledJob()
        {
            var scheduleDateTime = DateTime.UtcNow.AddSeconds(5);
            var dateTimeOffSet = new DateTimeOffset(scheduleDateTime);
            BackgroundJob.Schedule(() => Console.WriteLine("Sceduled Job Triggered"), dateTimeOffSet);
            
            return Ok();
        }

        [HttpPost]
        [Route("CreateRecurringJob")]
        public ActionResult CreateRecurringJob()
        {
            RecurringJob.AddOrUpdate("RecurringJob1", () => Console.WriteLine("Recurring Job Tirggered"), "* * * * *");

            

            return Ok();
        }

        [HttpPost]
        [Route("CreateFailJob")]
        public ActionResult CreateFailJob()
        {
            throw new Exception("Error intencional");
                    
            
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace Monitor_hangfire.Controllers
{
    //string mensaje = "Job1";
    public class ApiJobs 
    {
        static string[] mensaje = {""},{};
        [ApiController]
        [Route("api/[controller")]
        public class JobController : ControllerBase
        {
            [HttpGet]

            public IActionResult GetJob()
            {
                return Ok(new { mensaje});
            }
        }
    }
}

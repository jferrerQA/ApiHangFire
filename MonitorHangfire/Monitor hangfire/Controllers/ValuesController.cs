
using Microsoft.AspNetCore.Mvc;

namespace Monitor_hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Getob()
        {
            return Ok(new { mensaje = "Si" });
        }
    }
}

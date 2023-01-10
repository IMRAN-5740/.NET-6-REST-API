using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Versioning.Controllers
{
    [Route("api/user/[action]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class UserV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok("User V2 Controller");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Versioning.Controllers
{

    //Route for Query String Versioning
    [Route("api/user/[action]")]

    //Route for URI Versioning
    [Route("api/v{version:apiVersion}/user/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok("User V1 Controller");
        }
    }
}

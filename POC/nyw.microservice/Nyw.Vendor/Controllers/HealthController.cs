using Microsoft.AspNetCore.Mvc;

namespace Nyw.Vendor.Controllers {
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller {
        [HttpGet]
        public IActionResult Get() => Ok( $"{Request.Host.Value} is ok");
    }
}
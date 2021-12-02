using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Skeleton.Controllers
{
    public class SampleController : BaseApiController
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello");
        }
    }
}
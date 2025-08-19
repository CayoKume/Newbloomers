using Application.Jadlog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Shippment
{
#if DEBUG
    [ApiController]
    [Route("CarriersJobs/JadLog")]
    public class JadLogController : Controller
    {
        private readonly IJadlogService _jadlogService;

        public JadLogController(IJadlogService jadlogService) =>
            _jadlogService = jadlogService;

        [HttpPost("SearchTrackingHistory")]
        public async Task<ActionResult<string?>> SearchTrackingHistory()
        {
            await _jadlogService.SearchTrackingHistory();

            return Ok();
        }
    } 
#endif
}

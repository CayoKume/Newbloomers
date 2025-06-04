using Application.Jadlog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Shippment
{
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
            try
            {
                await _jadlogService.SearchTrackingHistory();

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Erro: {ex.Message}");
            }
        }
    }
}

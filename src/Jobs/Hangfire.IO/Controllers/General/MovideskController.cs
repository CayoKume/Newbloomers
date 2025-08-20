using Application.Movidesk.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.General
{
    [ApiController]
    [Route("MovideskJobs/Movidesk")]
    public class MovideskController : Controller
    {
        private readonly IMovideskService _movideskService;

        public MovideskController(
            IMovideskService movideskService
        )
        {
            _movideskService = movideskService;
        }

        [HttpPost("Persons")]
        public async Task<ActionResult> Persons()
        {
            var result = await _movideskService.GetPersons();

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("Services")]
        public async Task<ActionResult> Services()
        {
            var result = await _movideskService.GetServices();

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("Tickets")]
        public async Task<ActionResult> Tickets()
        {
            var result = await _movideskService.GetTickets();

            return Ok($"Records integrated successfully.");
        }
    }
}

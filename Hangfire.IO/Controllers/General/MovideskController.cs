using Application.Movidesk.Interfaces;
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
            try
            {
                var result = await _movideskService.GetPersons();

                if (result == true)
                    return Ok($"Records integrated successfully.");
                else
                    return BadRequest($"Unable to find records on endpoint.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("Services")]
        public async Task<ActionResult> Services()
        {
            try
            {
                var result = await _movideskService.GetServices();

                if (result == true)
                    return Ok($"Records integrated successfully.");
                else
                    return BadRequest($"Unable to find records on endpoint.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("Tickets")]
        public async Task<ActionResult> Tickets()
        {
            try
            {
                var result = await _movideskService.GetTickets();

                if (result == true)
                    return Ok($"Records integrated successfully.");
                else
                    return BadRequest($"Unable to find records on endpoint.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }
    }
}

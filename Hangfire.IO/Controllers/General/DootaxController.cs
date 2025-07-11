using Application.Dootax.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.General
{
    [ApiController]
    [Route("DootaxJobs/Dootax")]
    public class DootaxController : Controller
    {
        private readonly IDootaxService _dootaxService;

        public DootaxController(IDootaxService dootaxService) =>
            _dootaxService = dootaxService;

        [HttpPost("ImportFiles")]
        public async Task<ActionResult> ImportFiles()
        {
            try
            {
                var result = await _dootaxService.ImportFilesUpload();

                if (result == true)
                    return Ok($"Records integrated successfully.");
                else
                    return BadRequest($"Unable to find records on endpoint.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }
    }
}

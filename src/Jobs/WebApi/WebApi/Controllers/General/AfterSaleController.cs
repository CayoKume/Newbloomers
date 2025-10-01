using Application.AfterSale.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.General
{
    [ApiController]
    [Authorize]
#if RELEASE
    [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [Route("AfterSaleJobs/AfterSale")]
    public class AfterSaleController : Controller
    {
        private readonly IAfterSaleService _afterSaleService;

        public AfterSaleController(IAfterSaleService afterSaleService) =>
            _afterSaleService = afterSaleService;

        [HttpPost("Me")]
        public async Task<ActionResult> Me()
        {
            var result = await _afterSaleService.GetMe();

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("Reverses")]
        public async Task<ActionResult> Reverses()
        {
            var result = await _afterSaleService.GetReverses();

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("ReversesById")]
        public async Task<ActionResult> ReversesById([Required][FromQuery] string? cnpj_emp, [Required][FromQuery] Int64 id)
        {
            var result = await _afterSaleService.GetReversesById(cnpj_emp: cnpj_emp, id: id);

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("ReversesStatus")]
        public async Task<ActionResult> ReversesStatus()
        {
            var result = await _afterSaleService.GetReversesStatus();

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("Transportations")]
        public async Task<ActionResult> Transportations()
        {
            var result = await _afterSaleService.GetReversesTransportations();

            return Ok($"Records integrated successfully.");
        }
    } 
}

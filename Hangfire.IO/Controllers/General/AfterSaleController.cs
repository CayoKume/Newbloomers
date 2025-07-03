using Application.AfterSale.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.General
{
    [ApiController]
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

            if (result == true)
                return Ok($"Records integrated successfully.");
            else
                return BadRequest($"Unable to find records on endpoint.");
        }

        [HttpPost("Reverses")]
        public async Task<ActionResult> Reverses()
        {
            var result = await _afterSaleService.GetReverses();

            if (result == true)
                return Ok($"Records integrated successfully.");
            else
                return BadRequest($"Unable to find records on endpoint.");
        }

        [HttpPost("ReversesById")]
        public async Task<ActionResult> ReversesById([Required][FromQuery] string? cnpj_emp, [Required][FromQuery] Int64 id)
        {
            var result = await _afterSaleService.GetReversesById(cnpj_emp: cnpj_emp, id: id);

            if (result == true)
                return Ok($"Records integrated successfully.");
            else
                return BadRequest($"Unable to find records on endpoint.");
        }

        [HttpPost("ReversesStatus")]
        public async Task<ActionResult> ReversesStatus()
        {
            var result = await _afterSaleService.GetReversesStatus();

            if (result == true)
                return Ok($"Records integrated successfully.");
            else
                return BadRequest($"Unable to find records on endpoint.");
        }

        [HttpPost("Transportations")]
        public async Task<ActionResult> Transportations()
        {
            var result = await _afterSaleService.GetReversesTransportations();

            if (result == true)
                return Ok($"Records integrated successfully.");
            else
                return BadRequest($"Unable to find records on endpoint.");
        }
    }
}

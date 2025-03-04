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

        public AfterSaleController(
            IAfterSaleService afterSaleService
        )
        {
            _afterSaleService = afterSaleService;
        }

        [HttpPost("Me")]
        public async Task<ActionResult> Me()
        {
            try
            {
                var result = await _afterSaleService.GetMe();

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("Reverses")]
        public async Task<ActionResult> Reverses()
        {
            try
            {
                var result = await _afterSaleService.GetReverses();

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("ReversesById")]
        public async Task<ActionResult> ReversesById([Required][FromQuery] string? cnpj_emp, [Required][FromQuery] Int64 id)
        {
            try
            {
                var result = await _afterSaleService.GetReversesById(cnpj_emp: cnpj_emp, id: id);

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("ReversesStatus")]
        public async Task<ActionResult> ReversesStatus()
        {
            try
            {
                var result = await _afterSaleService.GetReversesStatus();

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("Transportations")]
        public async Task<ActionResult> Transportations()
        {
            try
            {
                var result = await _afterSaleService.GetReversesTransportations();

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }
    }
}

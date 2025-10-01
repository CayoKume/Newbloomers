using Application.Stone.Interfaces.Services;
using Application.TotalExpress.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.Carries
{
    [ApiController]
    [Authorize]
    [Route("CarriersJobs/StoneLogistica")]
    public class StoneLogisticaController : Controller
    {
        private readonly IStoneService _stoneService;

        public StoneLogisticaController(IStoneService stoneService) =>
            (_stoneService) = (stoneService);

        [HttpPost("StoneLogisticaCheckDeliveryOrders")]
        public async Task<ActionResult<string?>> StoneLogisticaCheckDeliveryOrders()
        {
            var result = await _stoneService.CheckDeliveryOrder();
            return Ok(result);
        }
    } 
}

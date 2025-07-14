using Application.TotalExpress.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.Carries
{
    [ApiController]
    [Route("CarriersJobs/TotalExpress")]
    public class TotalExpressController : Controller
    {
        private readonly ITotalExpressService _totalExpressService;

        public TotalExpressController(ITotalExpressService totalExpressService) =>
            (_totalExpressService) = (totalExpressService);

        [HttpPost("SendOrders")]
        public async Task<ActionResult<string?>> TotalExpressSendOrders()
        {
            await _totalExpressService.SendOrders();
            return Ok();
        }

        [HttpPost("SendOrder")]
        public async Task<ActionResult<string?>> TotalExpressSendOrder([Required][FromQuery] string? orderNumber)
        {
            var result = await _totalExpressService.SendOrder(orderNumber.Trim().ToUpper());

            return Ok($"Pedido: {orderNumber} enviado com sucesso.");
        }

        [HttpPost("SendOrderAsETUR")]
        public async Task<ActionResult<string?>> TotalExpressSendOrderAsETUR([Required][FromQuery] string? orderNumber)
        {
            var result = await _totalExpressService.SendOrderAsEtur(orderNumber.Trim().ToUpper());

            return Ok($"Pedido: {orderNumber} enviado com sucesso.");
        }

        [HttpPost("UpdateLogOrders")]
        public async Task<ActionResult<string?>> TotalExpressUpdateLogOrders()
        {
            await _totalExpressService.UpdateLogOrders();

            return Ok();
        }
    }
}

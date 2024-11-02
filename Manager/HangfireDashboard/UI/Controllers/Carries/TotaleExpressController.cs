using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TotalExpress.Application.Services;

namespace HangfireDashboard.UI.Controllers.Carries
{
    [ApiController]
    [Route("CarriersJobs/TotalExpress")]
    public class TotaleExpressController : Controller
    {
        private readonly ITotalExpressService _totalExpressService;

        public TotaleExpressController(ITotalExpressService totalExpressService) =>
            (_totalExpressService) = (totalExpressService);

        [HttpPost("SendOrders")]
        public async Task<ActionResult<string?>> TotalExpressSendOrders()
        {
            try
            {
                await _totalExpressService.SendOrders();
                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Erro: {ex.Message}");
            }
        }

        [HttpPost("SendOrder")]
        public async Task<ActionResult<string?>> TotalExpressSendOrder([Required][FromQuery] string? orderNumber)
        {
            try
            {
                var result = await _totalExpressService.SendOrder(orderNumber.Trim().ToUpper());

                if (result != true)
                    return BadRequest($"A API FlashCourier não conseguiu enviar o pedido: {orderNumber}.");
                else
                    return Ok($"Pedido: {orderNumber} enviado com sucesso.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel enviar o pedido: {orderNumber}. Erro: {ex.Message}");
            }
        }

        [HttpPost("SendOrderAsETUR")]
        public async Task<ActionResult<string?>> TotalExpressSendOrderAsETUR([Required][FromQuery] string? orderNumber)
        {
            try
            {
                var result = await _totalExpressService.SendOrderAsEtur(orderNumber.Trim().ToUpper());

                if (result != true)
                    return BadRequest($"A API FlashCourier não conseguiu enviar o pedido: {orderNumber}.");
                else
                    return Ok($"Pedido: {orderNumber} enviado com sucesso.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel enviar o pedido: {orderNumber}. Erro: {ex.Message}");
            }
        }

        [HttpPost("UpdateLogOrders")]
        public async Task<ActionResult<string?>> TotalExpressUpdateLogOrders()
        {
            try
            {
                await _totalExpressService.UpdateLogOrders();

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

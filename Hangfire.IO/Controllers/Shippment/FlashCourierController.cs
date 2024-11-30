using Application.FlashCourier.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.Carries
{
    [ApiController]
    [Route("CarriersJobs/FlashCourier")]
    public class FlashCourierController : Controller
    {
        private readonly IFlashCourierService _flashCourierService;

        public FlashCourierController(IFlashCourierService flashCourierService) =>
            (_flashCourierService) = (flashCourierService);

        [HttpPost("SendOrders")]
        public async Task<ActionResult<string?>> FlashCourierSendOrders()
        {
            try
            {
                await _flashCourierService.SendOrders();
                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Erro: {ex.Message}");
            }
        }

        [HttpPost("SendOrder")]
        public async Task<ActionResult<string?>> FlashCourierSendOrder([Required][FromQuery] string? orderNumber)
        {
            try
            {
                var result = await _flashCourierService.SendOrder(orderNumber.Trim().ToUpper());

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
        public async Task<ActionResult<string?>> FlashCourierUpdateLogOrders()
        {
            try
            {
                await _flashCourierService.UpdateLogOrders();

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

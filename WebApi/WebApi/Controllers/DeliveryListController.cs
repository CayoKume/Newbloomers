using Application.WebApi.Interfaces.Services;
using Domain.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WmsApi.Controllers
{
    [ApiController]
    [Route("NewBloomers/BloomersInvoiceIntegrations/MiniWms")]
    public class DeliveryListController : ControllerBase
    {
        //Refatorar Aqui (Adicione o Midleware de Erro aqui, ta facinho facinho)
        private readonly IDeliveryListService _deliveryListService;

        public DeliveryListController(IDeliveryListService deliveryListService) =>
            (_deliveryListService) = (deliveryListService);

        [HttpGet("GetDeliveryList")]
        public async Task<ActionResult<string>> GetDeliveryList([Required][FromQuery] string identificador)
        {
            try
            {
                var result = await _deliveryListService.GetDeliveryList(identificador);

                if (String.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar o romaneio: {identificador}.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar o romaneio: {identificador}. Erro: {ex.Message}");
            }
        }

        [HttpGet("GetDeliveryLists")]
        public async Task<ActionResult<string>> GetDeliveryLists([Required][FromQuery] string doc_company, [Required][FromQuery] string data_inicial, [Required][FromQuery] string data_final)
        {
            try
            {
                var result = await _deliveryListService.GetDeliveryLists(doc_company, data_inicial, data_final);

                if (String.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar os romaneios para o intervalo de datas determinado.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar os romaneios para o intervalo de datas determinado. Erro: {ex.Message}");
            }
        }

        [HttpGet("GetOrderShipped")]
        public async Task<ActionResult<string>> GetOrderShipped([Required][FromQuery] string cnpj_emp, [Required][FromQuery] string serie, [Required][FromQuery] string nr_pedido, [Required][FromQuery] string cod_transportadora)
        {
            try
            {
                var result = await _deliveryListService.GetOrderShipped(nr_pedido, serie, cnpj_emp, cod_transportadora);

                if (String.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar o pedido: {nr_pedido}.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar o pedido: {nr_pedido}. Erro: {ex.Message}");
            }
        }

        [HttpGet("GetOrdersShipped")]
        public async Task<ActionResult<string>> GetOrdersShipped([Required][FromQuery] string cod_transportadora, [Required][FromQuery] string cnpj_emp, [Required][FromQuery] string serie, [Required][FromQuery] string data_inicial, [Required][FromQuery] string data_final)
        {
            try
            {
                var result = await _deliveryListService.GetOrdersShipped(cod_transportadora, cnpj_emp, serie, data_inicial, data_final);

                if (String.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar os pedidos para o intervalo de datas determinado.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar os pedidos para o intervalo de datas determinado. Erro: {ex.Message}");
            }
        }

        [HttpPost("PrintDeliveryList")]
        public async Task<ActionResult<string>> PrintDeliveryList([FromBody] PrintOrdersRequest request)
        {
            try
            {
                var result = await _deliveryListService.PrintOrder(JsonConvert.SerializeObject(request.serializePedidosList));

                if (!result)
                    return BadRequest($"Nao foi possivel gerar o romaneio.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel gerar o romaneio. Erro: {ex.Message}");
            }
        }

        [HttpPost("SetColletedAtDate")]
        public async Task<ActionResult<string>> SetColletedAtDate([FromBody] SetColletedAtDateRequest identificador)
        {
            try
            {
                await _deliveryListService.SetColletedAtDate(identificador.uniqueidentifier);
                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel gerar o romaneio. Erro: {ex.Message}");
            }
        }

        [HttpGet("GetDeliveryListToPrint")]
        public async Task<ActionResult<string>> GetDeliveryListToPrint([Required][FromQuery] string fileName)
        {
            try
            {
                var result = await _deliveryListService.GetDeliveryListToPrint(fileName);

                if (String.IsNullOrEmpty(result))
                    return BadRequest($"Nao foi possivel encontrar a etiqueta: {fileName}.");
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Nao foi possivel encontrar o etiqueta: {fileName}. Erro: {ex.Message}");
            }
        }
    }

    //Refatorar Aqui (Mova essa classe para a Domain da API, ou melhor, pesquise qual é a melhor maneira de guardar essa classe, em qual camada?, em qual pasta?)
    public class PrintOrdersRequest
    {
        [Required(ErrorMessage = "A Lista de Pedidos é Obrigatória")]
        public List<Order>? serializePedidosList { get; set; }
    }

    //Refatorar Aqui (Mova essa classe para a Domain da API, ou melhor, pesquise qual é a melhor maneira de guardar essa classe, em qual camada?, em qual pasta?)
    public class SetColletedAtDateRequest
    {
        [Required(ErrorMessage = "O Identificaddor do Romaneio é Obrigatória")]
        public string? uniqueidentifier { get; set; }
    }
}

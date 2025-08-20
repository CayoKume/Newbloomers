using DeliveryList = Domain.WebApp.Entities.DeliveryList;
using Newtonsoft.Json;
using Application.WebApp.Interfaces.Api;
using Application.WebApp.ViewModels.DeliveryList;
using Application.WebApp.Interfaces.Services;

namespace Services
{
    public class DeliveryListService : IDeliveryListService
    {
        private readonly IAPICall _apiCall;

        public DeliveryListService(IAPICall apiCall) =>
            _apiCall = apiCall;

        public async Task<string> GetDeliveryListToPrint(string fileName)
        {
            var parameters = new Dictionary<string, string>
            {
                { "fileName",  fileName}
            };
            var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();

            return await _apiCall.GetAsync($"GetDeliveryListToPrint", encodedParameters);
        }

        public async Task<DeliveryList?> GetDeliveryList(string identificador)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "identificador", identificador }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetDeliveryList", encodedParameters);

                return System.Text.Json.JsonSerializer.Deserialize<DeliveryList>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DeliveryList>?> GetDeliveryLists(string cnpj_emp, DateTime? data_inicial, DateTime? data_final)
        {
            try
            {
                //Refatorar Aqui (quando corrigir a declaração das variavéis para date only na page, remover essa conversão que ficou uma bosta)
                DateTime dataInicial = (DateTime)data_inicial; 
                DateTime dataFinal = (DateTime)data_final;

                var parameters = new Dictionary<string, string>
                {
                    { "doc_company", cnpj_emp },
                    { "data_inicial", dataInicial.ToString("yyyy-MM-dd") },
                    { "data_final", dataFinal.ToString("yyyy-MM-dd") }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetDeliveryLists", encodedParameters);

                return System.Text.Json.JsonSerializer.Deserialize<List<DeliveryList>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Order?> GetOrderShipped(string nr_pedido, string serie, string cnpj_emp, string transportadora)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "cnpj_emp", cnpj_emp },
                    { "serie", serie },
                    { "nr_pedido", nr_pedido },
                    { "cod_transportadora", transportadora }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetOrderShipped", encodedParameters);

                return System.Text.Json.JsonSerializer.Deserialize<Order>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Order>?> GetOrdersShipped(string cod_transportadora, string cnpj_emp, string serie_pedido, string data_inicial, string data_final)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "cod_transportadora", cod_transportadora },
                    { "cnpj_emp", cnpj_emp },
                    { "serie", serie_pedido },
                    { "data_inicial", data_inicial },
                    { "data_final", data_final }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetOrdersShipped", encodedParameters);

                return System.Text.Json.JsonSerializer.Deserialize<List<Order>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task SetColletedAtDate(DeliveryList deliveryList)
        {
            try
            {
                var response = await _apiCall.PostAsync($"SetColletedAtDate", JsonConvert.SerializeObject(new { deliveryList.uniqueidentifier }));
            }
            catch
            {
                throw;
            }
        }

        public async Task PrintOrder(List<Order> pedidos)
        {
            try
            {
                var response = await _apiCall.PostAsync($"PrintDeliveryList", JsonConvert.SerializeObject(new { serializePedidosList = pedidos }));
            }
            catch
            {
                throw;
            }
        }
    }
}

using Application.Core.Interfaces;
using Application.TotalExpress.Interfaces;
using Domain.Core.Enums;
using Domain.TotalExpress.Entities;
using Domain.TotalExpress.Interfaces.Api;
using Domain.TotalExpress.Interfaces.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Application.TotalExpress.Services
{
    public class TotalExpressService : ITotalExpressService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ITotalExpressRepository _totalExpressRepository;

        public TotalExpressService(IAPICall apiCall, ITotalExpressRepository totalExpressRepository, ILoggerService logger) =>
            (_apiCall, _totalExpressRepository, _logger) = (apiCall, totalExpressRepository, logger);

        public async Task<bool> SendOrder(string? orderNumber)
        {
            try
            {
                var order = await _totalExpressRepository.GetInvoicedOrder(orderNumber);

                if (order != null)
                {
                    var parameters = await _totalExpressRepository.GetParameters(order.company.doc_company, order.shippment_method);
                    var jArray = BuildJObject(order, parameters);
                    var token = await GenerateToken(order.company.doc_company);
                    var headers = new Dictionary<string?, string?>
                    {
                        { "ContentType", "application/json" },
                        { "Authorization", token.token_type + " " + token.access_token }
                    };

                    for (int j = 0; j < jArray.Count(); j++)
                    {
                        await _totalExpressRepository.GenerateRequestLog(
                                            order.number,
                                            JsonConvert.SerializeObject(jArray[j])
                                        );

                        string? response = await _apiCall.PostAsync(
                            jArray[j],
                            "ics-edi/v1/coleta/smartLabel/registrar",
                            headers,
                            "TotalExpressAPI"
                        );

                        await _totalExpressRepository.GenerateResponseLog(
                            order.number,
                            parameters.sender_id,
                            response
                        );
                    }

                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendOrderAsEtur(string? orderNumber)
        {
            try
            {
                var order = await _totalExpressRepository.GetInvoicedOrder(orderNumber);

                if (order != null)
                {
                    var parameters = await _totalExpressRepository.GetParameters(order.company.doc_company, "ETUR");
                    var jArray = BuildJObject(order, parameters);
                    var token = await GenerateToken(order.company.doc_company);
                    var headers = new Dictionary<string?, string?>
                    {
                        { "ContentType", "application/json" },
                        { "Authorization", token.token_type + " " + token.access_token }
                    };

                    for (int j = 0; j < jArray.Count(); j++)
                    {
                        await _totalExpressRepository.GenerateRequestLog(
                                            order.number,
                                            JsonConvert.SerializeObject(jArray[j])
                                        );

                        string? response = await _apiCall.PostAsync(
                            jArray[j],
                            "ics-edi/v1/coleta/smartLabel/registrar",
                            headers,
                            "TotalExpressAPI"
                        );

                        await _totalExpressRepository.GenerateResponseLog(
                            order.number,
                            parameters.sender_id,
                            response
                        );
                    }

                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendOrders()
        {
            try
            {
                var orders = await _totalExpressRepository.GetInvoicedOrders();

                if (orders.Count() > 0)
                {
                    foreach (var order in orders)
                    {
                        var parameters = await _totalExpressRepository.GetParameters(order.company.doc_company, order.shippment_method);
                        var jArray = BuildJObject(order, parameters);
                        var token = await GenerateToken(order.company.doc_company);
                        var headers = new Dictionary<string?, string?>
                        {
                            { "ContentType", "application/json" },
                            { "Authorization", token.token_type + " " + token.access_token }
                        };

                        for (int j = 0; j < jArray.Count(); j++)
                        {
                            await _totalExpressRepository.GenerateRequestLog(
                                                order.number,
                                                JsonConvert.SerializeObject(jArray[j])
                                            );

                            string? response = await _apiCall.PostAsync(
                                jArray[j],
                                "ics-edi/v1/coleta/smartLabel/registrar",
                                headers,
                                "TotalExpressAPI"
                            );

                            await _totalExpressRepository.GenerateResponseLog(
                                order.number,
                                parameters.sender_id,
                                response
                            );
                        }
                    }

                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertLogOrdersByDateInterval()
        {
            try
            {
                var parameters = await _totalExpressRepository.GetSenderIds();

                if (parameters.Count() > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        var jObject = new JObject
                        {
                            { "remetenteId", 47812 },
                            //{ "data_inicial", DateTime.Now.Date.ToString("yyyy-MM-dd") }
                            //{ "remetenteId", "remetenteId" },
                            //{ "pedido", "OA-35289" }
                            { "awb", "TXAS614593325tx" }
                        };

                        var headers = new Dictionary<string?, string?>
                        {
                            { "ContentType", "application/xml" },
                            { "Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("apistatusnew-prod:GttTBS8x")) } //transformar em variável
                        };

                        try
                        {
                            string? response = await _apiCall.PostAsync(
                                                jObject,
                                                "previsao_entrega_atualizada.php",
                                                headers,
                                                "TotalExpressEdiAPI"
                                             );

                            var statusList = JsonConvert.DeserializeObject<IEnumerable<Status>>(response);
                            //var status = JsonConvert.DeserializeObject<Status>(response);

                            //foreach (var status in statusList)
                            //{
                            //    if (status.detalhes != null)
                            //    {
                            //        var lastStatus = status.detalhes.statusDeEncomenda.LastOrDefault();

                            //        var lastStatusDescription = lastStatus == null ?
                            //                                    null : $"{lastStatus.statusid} - {lastStatus.status}";

                            //        var lastStatusDate = lastStatus == null ?
                            //                             null : $"{lastStatus.data}";

                            //        var deliveryForecastDate = status.detalhes.dataPrev == null ?
                            //                           null : status.detalhes.dataPrev.PrevEntrega;

                            //        var collectionDate = status.detalhes.statusDeEncomenda.Where(p => p.status == "COLETA REALIZADA").FirstOrDefault() == null ?
                            //                         null : status.detalhes.statusDeEncomenda.Where(p => p.status == "COLETA REALIZADA").FirstOrDefault().data;

                            //        var deliveryMadeDate = status.detalhes.statusDeEncomenda.Where(p => p.status == "ENTREGA REALIZADA").FirstOrDefault() == null ?
                            //                         null : status.detalhes.statusDeEncomenda.Where(p => p.status == "ENTREGA REALIZADA").FirstOrDefault().data;

                            //        await _totalExpressRepository.UpdateDeliveryDates(
                            //            deliveryMadeDate,
                            //            collectionDate,
                            //            deliveryForecastDate,
                            //            lastStatusDate,
                            //            lastStatusDescription,
                            //            status.pedido
                            //        );
                            //    }
                            //}
                        }
                        catch (Exception ex) when (ex.Message.Contains("BadRequest"))
                        {
                            continue;
                        }
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> InsertLogOrdersByAWBs()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.TotalExpressTrackingHistory);

            var listStatus = new List<Status>();
            var listErrors = new List<Error>();

            var pedidos = await _totalExpressRepository.GetSenderAwbs();

            if (pedidos.Count() > 0)
            {
                foreach (var pedido in pedidos)
                {
                    var jObject = new JObject
                    {
                        { "remetenteId", pedido.remetenteid },
                        { "pedido", $"{pedido.pedido}" }
                    };

                    var headers = new Dictionary<string?, string?>
                    {
                        { "ContentType", "application/xml" },
                        { "Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("apistatusnew-prod:GttTBS8x")) } //transformar em variável
                    };

                    var response = await _apiCall.PostAsync(
                        "previsao_entrega_atualizada.php",
                        headers,
                        "TotalExpressEdiAPI",
                        jObject
                    );

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var res = await response.Content.ReadAsStringAsync();

                        if (res.IndexOf("{") == 0)
                        {
                            var status = JsonConvert.DeserializeObject<Status>(res);
                            listStatus.Add(new Status(status, res));
                        }
                        else
                        {
                            var statusList = JsonConvert.DeserializeObject<List<Status>>(res);

                            statusList
                                .ForEach(status => 
                                    listStatus.Add(new Status(status, res))
                            );
                        }
                    }
                    else
                        listErrors.Add(new Error(pedido: pedido.pedido, erro: await response.Content.ReadAsStringAsync()));
                }
            }

            if (listStatus.Count() > 0 || listErrors.Count() > 0)
            {
                await _totalExpressRepository.InsertStatus(listStatus, listErrors, new Guid());

                listStatus.ForEach(s =>
                    _logger.AddRecord(
                        s.pedido.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.pedido)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );

                listErrors.ForEach(s =>
                    _logger.AddRecord(
                        s.pedido.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.pedido)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );
            }

            _logger.AddMessage(
                    $"Concluída com sucesso: {listStatus.Count} registro(s) novo(s) inserido(s), {listErrors.Count} erro(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        private JArray BuildJObject(Order order, Parameters parameters)
        {
            var jArrayObj = new JArray();

            foreach (var item in order.itens)
            {
                var jObject = new JObject
                {
                    { "remetenteId", parameters.sender_id },
                    { "cnpj", order.company.doc_company },
                    { "encomendas", new JArray(
                        new JObject
                        {
                            { "servicoTipoInfo", null },
                            { "servicoTipo", parameters.service_type },
                            { "coletaInfo", String.Empty },
                            { "condFrete", "CIF" },
                            { "entregaTipo", 0 },
                            { "icmsIsencao", 0 },
                            { "natureza", item.description_product.Replace("Ç","C").Replace("Ú","U").PadRight(25).Substring(0, item.description_product.Length > 24 ? 24 : item.description_product.Length) },
                            { "pedido", order.number.Trim() },
                            { "peso", 0 },
                            { "volumes", order.volumes },
                            { "volumesTipo", "CX" },
                            { "clienteCodigo", int.Parse(order.client.cod_client) },
                            { "destinatario", new JObject
                                {
                                    { "nome", order.client.reason_client },
                                    { "cpfCnpj", order.client.doc_client },
                                    { "ie", order.client.state_registration_client },
                                    { "email", order.client.email_client },
                                    { "telefone1", order.client.fone_client.Replace("(","").Replace(")","").Replace("-","").Replace(" ","") },
                                    { "telefone2", "" },
                                    { "telefone3", "" },
                                    { "endereco", new JObject
                                        {
                                            { "bairro", order.client.neighborhood_client },
                                            { "cep", order.client.zip_code_client },
                                            { "cidade", order.client.city_client },
                                            { "complemento", order.client.complement_address_client },
                                            { "estado", order.client.uf_client },
                                            { "logradouro", order.client.address_client },
                                            { "numero", order.client.street_number_client },
                                            { "pais", "BR" },
                                            { "pontoReferencia", "" }
                                        }
                                    }
                                }
                            },
                            { "docFiscal", new JObject
                                {
                                    { "nfe", new JArray(
                                            new JObject
                                            {
                                                { "nfeCfop", order.cfop.Replace(".","") },
                                                { "nfeChave", order.invoice.key_nfe_nf },
                                                { "nfeData", order.invoice.date_emission_nf.ToString("dd-MM-yyyy") },
                                                { "nfeNumero", int.Parse(order.invoice.number_nf) },
                                                { "nfeSerie", order.invoice.serie_nf },
                                                { "nfeValProd", order.invoice.amount_nf },
                                                { "nfeValTotal", order.invoice.amount_nf }
                                            }
                                        )
                                    }
                                }
                            },
                        })
                    },
                };

                jArrayObj.Add(jObject);
            }

            return jArrayObj;
        }

        private async Task<Token?> GenerateToken(string? doc_company)
        {
            var jObject = new JObject
            {
                { "grant_type", "password" },
                { "username", "api-newbloomers" }, //transformar em variável
                { "password", "He7weir@o" } //transformar em variável
            };

            var headers = new Dictionary<string?, string?>
            {
                { "ContentType", "application/json" },
                { "Authorization", "Basic " + "SUNTOnRvdGFs" } //transformar em variável
            };

            var result = await _apiCall.PostAsync(
                jObject,
                "ics-seguranca/v1/oauth2/tokenGerar",
                headers,
                "TotalExpressAPI"
            );

            return JsonConvert.DeserializeObject<Token>(result);
        }
    }
}
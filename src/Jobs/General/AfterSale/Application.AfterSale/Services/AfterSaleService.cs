using Application.AfterSale.Interfaces.Api;
using Application.AfterSale.Interfaces.Services;
using Application.Core.Interfaces;
using Domain.AfterSale.Interfaces.Repositorys;
using Domain.AfterSale.Models;
using Domain.Core.Enums;
using Domain.Core.Extensions;
using FluentValidation;
using static Dapper.SqlMapper;

namespace Application.AfterSale.Services
{
    public class AfterSaleService : IAfterSaleService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IAfterSaleRepository _afterSaleRepository;

        private readonly IValidator<Domain.AfterSale.Dtos.Ecommerce> _ecommerceValidator;

        private static List<SimplifiedReverse?> GetReversesCache { get; set; } = new();
        private static List<string> GetMeJsonCache { get; set; } = new();
        private static string GetReversesTransportationsJsonCache = String.Empty;
        private static string GetReversesStatusJsonCache = String.Empty;

        public AfterSaleService(IAPICall apiCall, ILoggerService logger, IAfterSaleRepository afterSaleRepository, IValidator<Domain.AfterSale.Dtos.Ecommerce> ecommerceValidator) =>
            (_apiCall, _logger, _afterSaleRepository, _ecommerceValidator) = (apiCall, logger, afterSaleRepository, ecommerceValidator);

        #region Me - Infos about your ecommerce
        /// <summary>
        /// return infos about ecommerce, this method fills the tables: [AfterSaleEcommerces], [AfterSaleAddresses] and [AfterSaleReasons]
        /// </summary>
        public async Task<bool?> GetMe()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.AfterSaleEcommerces);

            var _listSomenteNovos = new List<Ecommerce>();
            var companys = await _afterSaleRepository.GetCompanys();

            foreach (var company in companys)
            {
                var response = await _apiCall.GetAsync(
                    token: company.Token.ToString(),
                    rote: "v3/api/me"
                );

                var hash = _logger.ComputeSha256Hash(response);

                if (!GetMeJsonCache.Any(x => x == $"{company.doc_company} - {hash}"))
                {
                    var me = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.AfterSale.Dtos.Me>(response);
                    var validations = _ecommerceValidator.Validate(me.data);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = String.Empty;
                        validations.Errors.ForEach(s =>
                            message += $"{s.ErrorMessage}\n"
                        );
                        _logger.AddMessage(message);
                    }

                    _listSomenteNovos.Add(new Ecommerce(ecommerce: me.data, json: response));

                    GetMeJsonCache.Add($"{company.doc_company} - {hash}");
                }
            }

            if (_listSomenteNovos.Count() > 0)
            {
                await _afterSaleRepository.InsertIntoAfterSaleEcommerce(_listSomenteNovos, _logger.GetExecutionGuid());

                _listSomenteNovos.ForEach(s =>
                    _logger.AddRecord(
                        s.uuid.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.uuid)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );
            }

            _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
        #endregion

        #region Refunds - Operations available to refunds
        /// <summary>
        /// returns all refunds
        /// </summary>
        public Task<bool?> GetRefunds()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns the possible actions of a reverse
        /// </summary>
        public Task<bool?> GetRefundsActions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns the possible banks of a refund
        /// </summary>
        public Task<bool?> GetRefundsBanks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get a refund
        /// </summary>
        public Task<bool?> GetRefundsById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns the possible status of a refund
        /// </summary>
        public Task<bool?> GetRefundsStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns the possible types of a refund
        /// </summary>
        public Task<bool?> GetRefundsTypes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// cancel reverse
        /// </summary>
        public Task<bool?> CancelRefundById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// change total amount of refund
        /// </summary>
        public Task<bool?> ChangeTotalAmountRefundById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// pay refund
        /// </summary>
        public Task<bool?> PayRefundById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// approve reverse
        /// </summary>
        /// <param name="id"></param>
        public Task<bool?> ApproveRefundById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Reverses - Operations available to reverses
        /// <summary>
        /// returns all reverses
        /// </summary>
        public async Task<bool?> GetReverses()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.AfterSaleReverses);

            var simplifiedReverses = new List<Domain.AfterSale.Dtos.Reverse>();
            var completeReverses = new List<Domain.AfterSale.Models.Reverse>();
            var companys = await _afterSaleRepository.GetCompanys();
            
            //pesquisa por id (só para depurar)
            //int[] ids = { };
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    simplifiedReverses.Add(new Domain.AfterSale.Dtos.Reverse { id = ids[i], updated_at = DateTime.Now });
            //}

            foreach (var company in companys)
            {
                var parameters = new Dictionary<string, string>
                {
                    { "start_date", $"{DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")}" },
                    { "end_date", $"{DateTime.Now.ToString("yyyy-MM-dd")}" }
                };

                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();

                var response = await _apiCall.GetAsync(
                    token: company.Token.ToString(),
                    rote: "v3/api/reverses",
                    encodedParameters: encodedParameters
                );

                var page = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.AfterSale.Dtos.ResponseReverses>(response);
                simplifiedReverses.AddRange(page.data);
                string? rote = page.next_page_url;
                int contador = 0;

                if (page.last_page > 1)
                {
                    while (!String.IsNullOrEmpty(rote))
                    {
                        //API da AfterSale lança Too Many Requests após 30 consultas, por isso caso tenha dado erro na consuta das páginas aguardamos por 1 minuto
                        if (contador > 14)
                        {
                            Thread.Sleep(60 * 1000);
                            contador = 0;
                        }

                        var responseByPage = await _apiCall.GetAsync(
                            token: company.Token.ToString(),
                            rote: rote.Replace("https://api.send4.com.br/", "")
                        );

                        var nextPage = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.AfterSale.Dtos.ResponseReverses>(responseByPage);

                        if (nextPage.success)
                        {
                            simplifiedReverses.AddRange(nextPage.data);
                            rote = nextPage.next_page_url;
                            contador++;
                            Thread.Sleep(10 * 1000);
                            continue;
                        }
                        Console.WriteLine("deu erro");
                    }
                }

                if (GetReversesCache.Count() == 0)
                    GetReversesCache = await _afterSaleRepository.GetReversesByIds(
                        simplifiedReverses.Select(x => x.id).ToList()
                    );

                simplifiedReverses.RemoveAll(x => GetReversesCache.Any(y =>
                   x.id == y.id &&
                   x.updated_at <= y.updated_at
                ));

                if (simplifiedReverses.Count() > 0)
                {
                    //API da AfterSale lança Too Many Requests após 30 consultas, por isso dividimos a lista _listSomenteNovos em indices de 30 consultas
                    int indice = simplifiedReverses.Count() / 30;

                    if (indice > 1 || simplifiedReverses.Count() > 30)
                    {
                        for (int i = 0; i <= indice; i++)
                        {
                            var top30List = simplifiedReverses.Skip(i * 30).Take(30).ToList();

                            for (int j = 0; j < top30List.Count(); j++)
                            {
                                var _response = await _apiCall.GetAsync(
                                    token: company.Token.ToString(),
                                    rote: $"v3/api/reverses/{top30List[j].id}"
                                );

                                try
                                {
                                    var completeReverse = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.AfterSale.Dtos.Root>(_response);

                                    if (completeReverse.success)
                                        completeReverses.Add(new Reverse(completeReverse.data, _response));

                                }
                                catch (Exception)
                                {
                                    throw;
                                }                                
                            }

                            //Espera 1 minuto após primeiro indice de 30 consultas
                            Thread.Sleep(60 * 1000);
                        }
                    }
                    else
                    {
                        foreach (var reverse in simplifiedReverses)
                        {
                            var _response = await _apiCall.GetAsync(
                                token: company.Token.ToString(),
                                rote: $"v3/api/reverses/{reverse.id}"
                            );

                            var completeReverse = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.AfterSale.Dtos.Root>(_response);

                            if (completeReverse.success)
                                completeReverses.Add(new Reverse(completeReverse.data, _response));
                        }
                    }
                }
            }

            if (completeReverses.Count() > 0)
            {
                await _afterSaleRepository.InsertIntoAfterSaleReverses(completeReverses, _logger.GetExecutionGuid());

                completeReverses.ForEach(s =>
                    _logger.AddRecord(
                        s.id.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.id)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );

                completeReverses.ForEach(s =>
                    GetReversesCache.Add(new SimplifiedReverse { id = s.id, updated_at = s.updated_at.Value })
                );
            }

            _logger.AddMessage(
                $"Concluída com sucesso: {completeReverses.Count} registro(s) novo(s) inserido(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        /// <summary>
        /// get a reverse
        /// </summary>
        /// <param name="id"></param>
        public async Task<bool?> GetReversesById(Int64 id, string cnpj_emp)
        {
            var company = await _afterSaleRepository.GetCompany(cnpj_emp);

            var response = await _apiCall.GetAsync(
                token: company.Token.ToString(),
                rote: $"v3/api/reverses/{id}"
            );

            //var page = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(response);

            //await _afterSaleRepository.InsertIntoAfterSaleReversesStatus(); 

            return true;
        }

        /// <summary>
        /// get courier data fields needed to process the reverse
        /// </summary>
        public Task<bool?> GetReversesCourierAttributes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns the possible status of a reverse
        /// </summary>
        public async Task<bool?> GetReversesStatus()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.AfterSaleStatus);

            var _listSomenteNovos = new List<Status>();
            var companys = await _afterSaleRepository.GetCompanys();

            foreach (var company in companys)
            {
                var response = await _apiCall.GetAsync(
                        token: company.Token.ToString(),
                        rote: "v3/api/reverses/status"
                    );

                var hash = _logger.ComputeSha256Hash(response);

                if (!GetReversesStatusJsonCache.Equals(hash))
                {
                    var status = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStatus>(response);

                    foreach (var _status in status.data)
                    {
                        //_listSomenteNovos.Add(new Status(status: _status, json: response));
                    }

                    GetReversesStatusJsonCache = hash;
                }
            }

            if (_listSomenteNovos.Count() > 0)
            {
                //await _afterSaleRepository.InsertIntoAfterSaleStatus(_listSomenteNovos, _logger.GetExecutionGuid());

                _listSomenteNovos.ForEach(s =>
                    _logger.AddRecord(
                        s.id.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.id)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );
            }

            _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        /// <summary>
        /// returns the possible transportations
        /// </summary>
        public async Task<bool?> GetReversesTransportations()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.AfterSaleTransportations);

            var _listSomenteNovos = new List<Transportations>();
            var companys = await _afterSaleRepository.GetCompanys();

            foreach (var company in companys)
            {
                var response = await _apiCall.GetAsync(
                        token: company.Token.ToString(),
                        rote: "v3/api/transportations"
                );

                var hash = _logger.ComputeSha256Hash(response);

                if (!GetReversesTransportationsJsonCache.Equals(hash))
                {
                    var transportations = Newtonsoft.Json.JsonConvert.DeserializeObject<Transportations>(response);

                    foreach (var transportation in transportations.data)
                    {
                        _listSomenteNovos.Add(new Transportations(transportation: transportation, recordKey: $"{company.doc_company} - {hash}", json: response));
                    }

                    GetReversesTransportationsJsonCache = hash;
                }
            }

            if (_listSomenteNovos.Count() > 0)
            {
                //await _afterSaleRepository.InsertIntoAfterSaleTransportations(_listSomenteNovos, _logger.GetExecutionGuid());

                _listSomenteNovos.ForEach(s =>
                    _logger.AddRecord(
                        s.RecordKey.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.RecordKey)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );
            }

            _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        /// <summary>
        /// receive products by reverse ID
        /// </summary>
        /// <param name="id"></param>
        public Task<bool?> ReciveProductsById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update recived invoice in reverse products. Need pass the products id and the returned invoice
        /// </summary>
        /// <param name="id"></param>
        public Task<bool?> ReturnedInvoiceById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// set reverse courier data and process/generate code
        /// </summary>
        /// <param name="id"></param>
        public Task<bool?> ReversesInvoiceById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// approve products by reverse ID
        /// </summary>
        /// <param name="id"></param>
        public Task<bool?> ApproveReverseById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

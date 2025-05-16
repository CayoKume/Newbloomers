using Application.AfterSale.Interfaces;
using Domain.AfterSale.Entities;
using Domain.AfterSale.Interfaces.Api;
using Domain.AfterSale.Interfaces.Repositorys;
namespace Application.AfterSale.Services
{
    public class AfterSaleService : IAfterSaleService
    {
        private readonly IAPICall _apiCall;
        private readonly IAfterSaleRepository _afterSaleRepository;

        public AfterSaleService(IAPICall apiCall, IAfterSaleRepository afterSaleRepository) =>
            (_apiCall, _afterSaleRepository) = (apiCall, afterSaleRepository);

        #region Me - Infos about your ecommerce
        /// <summary>
        /// return infos about ecommerce
        /// </summary>
        public async Task<bool?> GetMe()
        {
            try
            {
                var companys = await _afterSaleRepository.GetCompanys();

                foreach (var company in companys)
                {
                    var response = await _apiCall.GetAsync(
                        token: company.Token.ToString(),
                        rote: "v3/api/me"
                    );

                    var me = Newtonsoft.Json.JsonConvert.DeserializeObject<Me>(response);
                }

                return true;
            }
            catch
            {
                throw;
            }
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
            try
            {
                var companys = await _afterSaleRepository.GetCompanys();

                foreach (var company in companys)
                {
                    var simplifiedReverses = new List<ReverseSimplified>();
                    var completeReverses = new List<Data>();

                    var parameters = new Dictionary<string, string>
                    {
                        { "start_date", $"{DateTime.Now.AddMonths(-2).ToString("yyyy-MM-dd")}" },
                        { "end_date", $"{DateTime.Now.ToString("yyyy-MM-dd")}" }
                    };
                    var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();

                    var response = await _apiCall.GetAsync(
                        token: company.Token.ToString(),
                        rote: "v3/api/reverses",
                        encodedParameters: encodedParameters
                    );

                    var page = Newtonsoft.Json.JsonConvert.DeserializeObject<GetReverses>(response);
                    simplifiedReverses.AddRange(page.data);
                    string? rote = page.next_page_url;

                    if (page.last_page > 1)
                    {
                        while (!String.IsNullOrEmpty(rote))
                        {
                            var responseByPage = await _apiCall.GetAsync(
                                token: company.Token.ToString(),
                                rote: rote.Replace("https://api.send4.com.br/", "")
                            );

                            var nextPage = Newtonsoft.Json.JsonConvert.DeserializeObject<GetReverses>(responseByPage);
                            simplifiedReverses.AddRange(nextPage.data);
                            rote = nextPage.next_page_url; 
                        }

                        foreach (var reverse in simplifiedReverses)
                        {
                            var _response = await _apiCall.GetAsync(
                                token: company.Token.ToString(),
                                rote: $"v3/api/reverses/{reverse.id}"
                            );

                            var completeReverse = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(_response);

                            completeReverses.Add(completeReverse.data);
                        }
                    }

                    await _afterSaleRepository.InsertIntoAfterSaleReverses(completeReverses); 
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get a reverse
        /// </summary>
        /// <param name="id"></param>
        public async Task<bool?> GetReversesById(Int64 id, string cnpj_emp)
        {
            try
            {
                var company = await _afterSaleRepository.GetCompany(cnpj_emp);

                var response = await _apiCall.GetAsync(
                    token: company.Token.ToString(),
                    rote: $"v3/api/reverses/{id}"
                );

                var page = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(response);

                //await _afterSaleRepository.InsertIntoAfterSaleReversesStatus(); 

                return true;
            }
            catch
            {
                throw;
            }
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
            try
            {
                var companys = await _afterSaleRepository.GetCompanys();

                var response = await _apiCall.GetAsync(
                    token: companys.FirstOrDefault().Token.ToString(),
                    rote: "v3/api/reverses/status"
                );

                var status = Newtonsoft.Json.JsonConvert.DeserializeObject<GetStatus>(response);

                await _afterSaleRepository.InsertIntoAfterSaleReversesStatus(status.data);

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// returns the possible transportations
        /// </summary>
        public async Task<bool?> GetReversesTransportations()
        {
            try
            {
                var companys = await _afterSaleRepository.GetCompanys();

                var response = await _apiCall.GetAsync(
                    token: companys.FirstOrDefault().Token.ToString(),
                    rote: "v3/api/transportations"
                );

                var transportations = Newtonsoft.Json.JsonConvert.DeserializeObject<Transportations>(response);

                await _afterSaleRepository.InsertIntoAfterSaleReversesTransportations(transportations);

                return true;
            }
            catch
            {
                throw;
            }
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

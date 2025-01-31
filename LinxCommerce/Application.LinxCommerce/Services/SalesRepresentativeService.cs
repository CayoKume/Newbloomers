using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Entities.SalesRepresentative;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys.SalesRepresentative;

namespace Application.LinxCommerce.Services
{
    public class SalesRepresentativeService : ISalesRepresentativeService
    {
        private readonly IAPICall _apiCall;
        private readonly ISalesRepresentativeRepository _salesRepresentativeRepository;

        public SalesRepresentativeService(IAPICall apiCall, ISalesRepresentativeRepository salesRepresentativeRepository) =>
            (_apiCall, _salesRepresentativeRepository) = (apiCall, salesRepresentativeRepository);

        public Task<string?> DeleteSalesRepresentative(int salesRepresentativeId)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetSalesRepresentative(LinxCommerceJobParameter jobParameter, int? salesRepresentativeId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        public Task<string?> SaveSalesRepresentative()
        {
            throw new NotImplementedException();
        }

        public async Task<string?> SearchSalesRepresentative(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    Where = $"",
                    WhereMetadata = "",
                    OrderBy = "",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Sales/API.svc/web/SearchSalesRepresentative"
                );

                var salesRepresentativeList = new List<SalesRepresentative>();
                var salesRepresentativeIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchSalesRepresentative.Root>(response);

                foreach (var salesRepresentativeID in salesRepresentativeIDs.Result)
                {
                    var getSaleRepresentativeObjectRequest = new
                    {
                        salesRepresentativeID.SalesRepresentativeID
                    };

                    var getSaleRepresentativeResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        objRequest: getSaleRepresentativeObjectRequest,
                        route: "/v1/Sales/API.svc/web/GetSalesRepresentative"
                    );

                    var saleRepresentative = Newtonsoft.Json.JsonConvert.DeserializeObject<GetSalesRepresentative.Root>(getSaleRepresentativeResponse);

                    salesRepresentativeList.Add(saleRepresentative.SalesRepresentative);
                }

                _salesRepresentativeRepository.BulkInsertIntoTableRaw(jobParameter: jobParameter, registros: salesRepresentativeList);

                return "true";
            }
            catch
            {
                throw;
            }
        }
    }
}

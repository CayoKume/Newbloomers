using Application.App.Interfaces.Api;
using Application.App.Interfaces.Services;
using Domain.App.Entities;
using System.Text.Json;

namespace Application.App.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IAPICall _apiCall;

        public CompanyService(IAPICall apiCall) =>
            (_apiCall) = (apiCall);

        public async Task<List<Company>?> GetCompanies()
        {
            try
            {
                var result = await _apiCall.GetAsync("GetCompanys");
                return JsonSerializer.Deserialize<List<Company>>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}

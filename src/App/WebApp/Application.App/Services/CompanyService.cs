using Domain.WebApp.Entities;
using Application.WebApp.Interfaces.Api;
using Application.WebApp.Interfaces.Services;
using System.Text.Json;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IAPICall _apiCall;

        public CompanyService(IAPICall apiCall) =>
            _apiCall = apiCall;

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

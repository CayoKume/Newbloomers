using Domain.WebApi.Interfaces.Repositorys;
using Application.WebApi.Interfaces.Services;
using Newtonsoft.Json;

namespace Application.WebApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) =>
            _companyRepository = companyRepository;

        public async Task<string> GetCompanys()
        {
            var list = await _companyRepository.GetCompanys();
            return JsonConvert.SerializeObject(list);
        }

        public async Task<string> GetUsers()
        {
            var list = await _companyRepository.GetUsers();
            return JsonConvert.SerializeObject(list);
        }
    }
}

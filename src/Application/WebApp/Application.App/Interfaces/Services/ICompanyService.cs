using Domain.WebApp.Entities;

namespace Application.WebApp.Interfaces.Services
{
    public interface ICompanyService
    {
        public Task<List<Company>?> GetCompanies();
    }
}

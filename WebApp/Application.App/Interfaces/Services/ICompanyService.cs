using Domain.App.Entities;

namespace Application.App.Interfaces.Services
{
    public interface ICompanyService
    {
        public Task<List<Company>?> GetCompanies();
    }
}

using Domain.Wms.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>?> GetCompanys();
        public Task<IEnumerable<User>?> GetUsers();
    }
}

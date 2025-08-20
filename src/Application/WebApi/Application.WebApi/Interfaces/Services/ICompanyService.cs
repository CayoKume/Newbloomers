namespace Application.WebApi.Interfaces.Services
{
    public interface ICompanyService
    {
        public Task<string> GetCompanys();
        public Task<string> GetUsers();
    }
}

using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using Domain.WebApi.Models;

namespace Infrastructure.WebApi.Repositorys
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly ICompanyCommandHandler _companyCommandHandler;

        public CompanyRepository(ISQLServerConnection conn, ICompanyCommandHandler companyCommandHandler) =>
            (_conn, _companyCommandHandler) = (conn, companyCommandHandler);

        public async Task<IEnumerable<Company>?> GetCompanys()
        {
            var sql = _companyCommandHandler.CreateGetCompanysQuery();

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    return await conn.QueryAsync<Company>(sql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Companys] - GetCompanys - Erro ao obter empresa da tabela LinxLojas_trusted  - {ex.Message}");
            }
        }

        public Task<IEnumerable<User>?> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}

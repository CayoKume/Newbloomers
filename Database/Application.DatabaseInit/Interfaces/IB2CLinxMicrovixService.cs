using Domain.IntegrationsCore.Entities.Parameters;

namespace Application.DatabaseInit.Interfaces
{
    public interface IB2CLinxMicrovixService
    {
        public Task<bool> InsertParametersIfNotExists(List<LinxMethods> listMethods);
        public Task<bool> CreateTablesIfNotExists(List<LinxMethods> listMethods);
        public Task<bool> CreateTablesMerges(List<LinxMethods> listMethods);
    }
}

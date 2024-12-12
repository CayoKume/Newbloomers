using Domain.DatabaseInit.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Application.DatabaseInit.Interfaces
{
    public interface IB2CLinxMicrovixService
    {
        public Task<bool> InsertParametersIfNotExists(Parameter parameters, List<LinxMethods>? listMethods);
        public Task<bool> CreateTablesIfNotExists(Parameter parameters, List<LinxMethods>? listMethods);
        public Task<bool> CreateTablesMerges(Parameter parameters, List<LinxMethods>? listMethods);
    }
}

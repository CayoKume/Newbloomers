using Domain.IntegrationsCore.Entities.Parameters;

namespace Application.DatabaseInit.Interfaces
{
    public interface IB2CLinxMicrovixService
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter, List<LinxMethods> listMethods);
        public Task<bool> CreateTablesIfNotExists(LinxMicrovixJobParameter linxMicrovixJobParameter, List<LinxMethods> listMethods);
        public Task<bool> CreateTablesMerges(LinxMicrovixJobParameter linxMicrovixJobParameter, List<LinxMethods> listMethods);
    }
}

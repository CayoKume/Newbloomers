using Domain.IntegrationsCore.Entities.Parameters;

namespace DatabaseInit.Domain.Interfaces.LinxMicrovix
{
    public interface ILinxVendedoresRepository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
    }
}

using Domain.IntegrationsCore.Entities.Parameters;

namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix
{
    public interface ILinxVendedoresRepository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public bool CreateTableIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
    }
}

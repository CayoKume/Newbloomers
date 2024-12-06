using Domain.IntegrationsCore.Entities.Parameters;

namespace Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce
{
    public interface IB2CConsultaProdutosFlagsRepository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public bool CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
    }
}

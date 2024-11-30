using Domain.IntegrationsCore.Entities.Parameters;

namespace DatabaseInit.Domain.Interfaces.LinxCommerce
{
    public interface IB2CConsultaGrade1Repository
    {
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
    }
}

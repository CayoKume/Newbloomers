using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaVendedoresRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaVendedores? record);
        public Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter);
        public Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<B2CConsultaVendedores> records);
        public Task<List<B2CConsultaVendedores>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<B2CConsultaVendedores> registros);
    }
}

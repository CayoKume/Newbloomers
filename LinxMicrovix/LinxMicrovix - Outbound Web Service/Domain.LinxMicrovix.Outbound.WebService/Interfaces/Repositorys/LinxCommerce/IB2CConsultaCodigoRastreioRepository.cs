using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce
{
    public interface IB2CConsultaCodigoRastreioRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaCodigoRastreio? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaCodigoRastreio> records);
        public Task<List<B2CConsultaCodigoRastreio>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaCodigoRastreio> registros);
    }
}

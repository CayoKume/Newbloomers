using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecCreditoAvulsoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCreditoAvulso? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCreditoAvulso> records);
        public Task<List<LinxClientesFornecCreditoAvulso>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCreditoAvulso> registros);
    }
}

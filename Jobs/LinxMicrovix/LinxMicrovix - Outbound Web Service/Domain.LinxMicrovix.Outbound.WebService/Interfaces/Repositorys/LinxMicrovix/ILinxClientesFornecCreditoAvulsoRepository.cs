using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClientesFornecCreditoAvulsoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxClientesFornecCreditoAvulso? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxClientesFornecCreditoAvulso> records);
        public Task<IEnumerable<LinxClientesFornecCreditoAvulso>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxClientesFornecCreditoAvulso> registros);
    }
}

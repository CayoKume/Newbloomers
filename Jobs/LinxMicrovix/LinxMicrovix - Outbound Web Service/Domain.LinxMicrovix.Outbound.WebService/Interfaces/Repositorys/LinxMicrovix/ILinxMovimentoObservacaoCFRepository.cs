using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoObservacaoCFRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoObservacaoCF? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoObservacaoCF> records);
        public Task<IEnumerable<LinxMovimentoObservacaoCF>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoObservacaoCF> registros);
    }
}

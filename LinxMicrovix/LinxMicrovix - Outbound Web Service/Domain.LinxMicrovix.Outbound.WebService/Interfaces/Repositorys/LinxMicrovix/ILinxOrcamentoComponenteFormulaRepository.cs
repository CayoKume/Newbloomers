using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxOrcamentoComponenteFormulaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxOrcamentoComponenteFormula? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxOrcamentoComponenteFormula> records);
        public Task<List<LinxOrcamentoComponenteFormula>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxOrcamentoComponenteFormula> registros);
    }
}

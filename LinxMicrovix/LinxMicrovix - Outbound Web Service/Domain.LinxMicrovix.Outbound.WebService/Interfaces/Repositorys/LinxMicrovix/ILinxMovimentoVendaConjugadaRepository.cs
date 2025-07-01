using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoVendaConjugadaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoVendaConjugada? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoVendaConjugada> records);
        public Task<IEnumerable<LinxMovimentoVendaConjugada>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoVendaConjugada> registros);
    }
}

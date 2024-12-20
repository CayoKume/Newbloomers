using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMovimentoVendaConjugadaRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoVendaConjugada? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoVendaConjugada> records);
        public Task<List<LinxMovimentoVendaConjugada>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoVendaConjugada> registros);
    }
}

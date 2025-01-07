using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAntecipacoesFinanceirasRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAntecipacoesFinanceiras? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAntecipacoesFinanceiras> records);
        public Task<List<LinxAntecipacoesFinanceiras>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAntecipacoesFinanceiras> registros);
    }
}

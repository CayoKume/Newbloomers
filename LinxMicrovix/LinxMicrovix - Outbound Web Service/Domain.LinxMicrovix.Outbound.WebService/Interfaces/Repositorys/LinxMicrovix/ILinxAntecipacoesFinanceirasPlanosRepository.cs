using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAntecipacoesFinanceirasPlanosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxAntecipacoesFinanceirasPlanos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxAntecipacoesFinanceirasPlanos> records);
        public Task<List<LinxAntecipacoesFinanceirasPlanos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxAntecipacoesFinanceirasPlanos> registros);
    }
}

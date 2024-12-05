using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAntecipacoesFinanceirasPlanosRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxAntecipacoesFinanceirasPlanos? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxAntecipacoesFinanceirasPlanos> records);
        public Task<List<LinxAntecipacoesFinanceirasPlanos>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxAntecipacoesFinanceirasPlanos> registros);
    }
}

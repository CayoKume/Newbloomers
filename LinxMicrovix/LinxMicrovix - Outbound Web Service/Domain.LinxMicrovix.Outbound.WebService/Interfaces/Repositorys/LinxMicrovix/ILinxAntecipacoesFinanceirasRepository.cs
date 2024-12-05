using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxAntecipacoesFinanceirasRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxAntecipacoesFinanceiras? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxAntecipacoesFinanceiras> records);
        public Task<List<LinxAntecipacoesFinanceiras>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxAntecipacoesFinanceiras> registros);
    }
}

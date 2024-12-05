using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxClassificacoesRepository
    {
        public Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, LinxClassificacoes? record);
        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, IList<LinxClassificacoes> records);
        public Task<List<LinxClassificacoes>> GetRegistersExists(LinxMicrovixJobParameter jobParameter, List<LinxClassificacoes> registros);
    }
}

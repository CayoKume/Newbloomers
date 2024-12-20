using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMotivoDevolucaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDevolucao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDevolucao> records);
        public Task<List<LinxMotivoDevolucao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDevolucao> registros);
    }
}

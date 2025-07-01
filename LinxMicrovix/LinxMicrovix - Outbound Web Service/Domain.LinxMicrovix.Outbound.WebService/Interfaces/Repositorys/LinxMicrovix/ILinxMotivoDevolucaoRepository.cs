using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMotivoDevolucaoRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMotivoDevolucao? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMotivoDevolucao> records);
        public Task<IEnumerable<LinxMotivoDevolucao>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMotivoDevolucao> registros);
    }
}

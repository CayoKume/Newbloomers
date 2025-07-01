using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxServicosRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxServicos? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxServicos> records);
        public Task<IEnumerable<LinxServicos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxServicos> registros);
    }
}

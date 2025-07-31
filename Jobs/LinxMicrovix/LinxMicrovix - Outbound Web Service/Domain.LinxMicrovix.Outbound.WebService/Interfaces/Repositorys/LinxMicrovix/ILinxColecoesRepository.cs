using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxColecoesRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxColecoes? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxColecoes> records);
        public Task<IEnumerable<LinxColecoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxColecoes> registros);
    }
}

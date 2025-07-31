using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxNfseRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNfse? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNfse> records);
        public Task<IEnumerable<LinxNfse>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNfse> registros);
    }
}

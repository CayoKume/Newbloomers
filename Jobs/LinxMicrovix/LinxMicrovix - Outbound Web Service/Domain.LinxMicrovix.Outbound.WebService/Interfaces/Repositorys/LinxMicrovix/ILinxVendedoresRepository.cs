using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxVendedoresRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxVendedores? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxVendedores> records);
        public Task<IEnumerable<string>> GetRegistersExists();
    }
}

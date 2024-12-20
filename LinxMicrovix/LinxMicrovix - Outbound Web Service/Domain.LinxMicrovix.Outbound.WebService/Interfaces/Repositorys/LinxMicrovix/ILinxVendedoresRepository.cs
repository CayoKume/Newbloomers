using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxVendedoresRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxVendedores? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, List<LinxVendedores> records);
        public Task<List<LinxVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxVendedores> registros);
    }
}

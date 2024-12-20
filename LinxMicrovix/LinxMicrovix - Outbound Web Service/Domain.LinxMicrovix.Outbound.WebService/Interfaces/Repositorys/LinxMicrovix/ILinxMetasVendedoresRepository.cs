using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix
{
    public interface ILinxMetasVendedoresRepository
    {
        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedores? record);
        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedores> records);
        public Task<List<LinxMetasVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedores> registros);
    }
}

using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxComissoesVendedoresRepository : ILinxComissoesVendedoresRepository
    {
        public LinxComissoesVendedoresRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxComissoesVendedores> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxComissoesVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxComissoesVendedores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxComissoesVendedores? record)
        {
            throw new NotImplementedException();
        }
    }
}

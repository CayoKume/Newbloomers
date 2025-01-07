using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMetasVendedoresRepository : ILinxMetasVendedoresRepository
    {
        public LinxMetasVendedoresRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetasVendedores> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMetasVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetasVendedores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetasVendedores? record)
        {
            throw new NotImplementedException();
        }
    }
}

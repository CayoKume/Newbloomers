using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxComissoesVendedores>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxComissoesVendedores> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxComissoesVendedores? record)
        {
            throw new NotImplementedException();
        }
    }
}

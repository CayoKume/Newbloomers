using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxRemessasRetornoTiposRepository : ILinxRemessasRetornoTiposRepository
    {
        public LinxRemessasRetornoTiposRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRemessasRetornoTipos> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxRemessasRetornoTipos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasRetornoTipos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasRetornoTipos? record)
        {
            throw new NotImplementedException();
        }
    }
}

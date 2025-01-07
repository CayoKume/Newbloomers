using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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

        public Task<List<LinxRemessasRetornoTipos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRemessasRetornoTipos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRemessasRetornoTipos? record)
        {
            throw new NotImplementedException();
        }
    }
}

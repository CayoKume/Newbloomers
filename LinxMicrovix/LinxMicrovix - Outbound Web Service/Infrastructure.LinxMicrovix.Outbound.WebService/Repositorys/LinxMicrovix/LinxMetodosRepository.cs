using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMetodosRepository : ILinxMetodosRepository
    {
        public LinxMetodosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMetodos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMetodos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetodos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetodos? record)
        {
            throw new NotImplementedException();
        }
    }
}

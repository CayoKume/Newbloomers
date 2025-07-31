using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxMetodos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMetodos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMetodos? record)
        {
            throw new NotImplementedException();
        }
    }
}

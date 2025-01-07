using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxNFeEventoRepository : ILinxNFeEventoRepository
    {
        public LinxNFeEventoRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxNFeEvento> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxNFeEvento>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxNFeEvento> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxNFeEvento? record)
        {
            throw new NotImplementedException();
        }
    }
}

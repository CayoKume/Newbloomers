using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxReducoesZRepository : ILinxReducoesZRepository
    {
        public LinxReducoesZRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxReducoesZ> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxReducoesZ>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxReducoesZ> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxReducoesZ? record)
        {
            throw new NotImplementedException();
        }
    }
}

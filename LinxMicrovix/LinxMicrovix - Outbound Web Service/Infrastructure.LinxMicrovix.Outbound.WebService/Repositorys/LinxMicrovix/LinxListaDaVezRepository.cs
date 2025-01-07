using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxListaDaVezRepository : ILinxListaDaVezRepository
    {
        public LinxListaDaVezRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxListaDaVez> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxListaDaVez>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxListaDaVez> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxListaDaVez? record)
        {
            throw new NotImplementedException();
        }
    }
}

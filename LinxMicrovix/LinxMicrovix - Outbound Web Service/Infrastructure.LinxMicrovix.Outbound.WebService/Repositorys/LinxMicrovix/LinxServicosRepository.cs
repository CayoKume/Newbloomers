using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxServicosRepository : ILinxServicosRepository
    {
        public LinxServicosRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxServicos> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxServicos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxServicos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxServicos? record)
        {
            throw new NotImplementedException();
        }
    }
}

using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
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

        public Task<IEnumerable<LinxServicos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxServicos> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxServicos? record)
        {
            throw new NotImplementedException();
        }
    }
}

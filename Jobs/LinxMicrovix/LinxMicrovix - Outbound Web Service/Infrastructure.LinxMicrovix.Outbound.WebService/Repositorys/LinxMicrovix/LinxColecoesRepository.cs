using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxColecoesRepository : ILinxColecoesRepository
    {
        public LinxColecoesRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxColecoes> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxColecoes>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxColecoes> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxColecoes? record)
        {
            throw new NotImplementedException();
        }
    }
}

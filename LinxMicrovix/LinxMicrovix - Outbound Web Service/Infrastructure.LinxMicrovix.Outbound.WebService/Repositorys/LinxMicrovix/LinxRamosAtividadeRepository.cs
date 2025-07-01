using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxRamosAtividadeRepository : ILinxRamosAtividadeRepository
    {
        public LinxRamosAtividadeRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxRamosAtividade> records)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LinxRamosAtividade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRamosAtividade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRamosAtividade? record)
        {
            throw new NotImplementedException();
        }
    }
}

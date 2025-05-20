using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix
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

        public Task<List<LinxRamosAtividade>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxRamosAtividade> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxRamosAtividade? record)
        {
            throw new NotImplementedException();
        }
    }
}

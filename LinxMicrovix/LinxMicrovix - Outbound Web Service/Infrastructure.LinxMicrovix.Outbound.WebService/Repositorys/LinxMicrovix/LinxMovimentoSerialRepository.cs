using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoSerialRepository : ILinxMovimentoSerialRepository
    {
        public LinxMovimentoSerialRepository()
        {

        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoSerial> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoSerial>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoSerial> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoSerial? record)
        {
            throw new NotImplementedException();
        }
    }
}

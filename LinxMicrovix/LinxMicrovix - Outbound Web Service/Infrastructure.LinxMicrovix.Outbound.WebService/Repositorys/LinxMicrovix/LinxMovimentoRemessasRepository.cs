using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoRemessasRepository : ILinxMovimentoRemessasRepository
    {
        public LinxMovimentoRemessasRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessas> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoRemessas>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessas> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessas? record)
        {
            throw new NotImplementedException();
        }
    }
}

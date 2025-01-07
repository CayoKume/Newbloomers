using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxMovimentoRemessasItensRepository : ILinxMovimentoRemessasItensRepository
    {
        public LinxMovimentoRemessasItensRepository()
        {
            
        }

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimentoRemessasItens> records)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinxMovimentoRemessasItens>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimentoRemessasItens> registros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimentoRemessasItens? record)
        {
            throw new NotImplementedException();
        }
    }
}
